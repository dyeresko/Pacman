using System.Collections;
using UnityEngine;

public class GhostHome : GhostBehavior
{
    public Transform inside;
    public Transform outside;

    private void OnEnable()
    {
        StopAllCoroutines();
    }
    private void OnDisable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            this.ghost.movement.SetDirection(-this.ghost.movement.direction);
        }
    }
    private IEnumerator ExitTransition()
    {
        this.ghost.movement.rigidbody.isKinematic = true;
        this.ghost.movement.enabled = false;

        float duration = 0.5f;
        float elapsed = 0.0f;
        Vector3 position = this.transform.position;
        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, inside.position, elapsed / duration);
            this.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0.0f;
        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(inside.position, outside.position, elapsed / duration);
            this.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        this.ghost.movement.rigidbody.isKinematic = false;
        this.ghost.movement.enabled = true;
        this.ghost.movement.SetDirection(new Vector2(Random.value < 0.5 ? -1.0f : 1.0f, 0));

    }
}
