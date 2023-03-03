using UnityEngine;

public class GhostScatter : GhostBehavior
{

    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        if (node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            int index = Random.Range(0, node.availableDirections.Count - 1);
            if (node.availableDirections[index] == -this.ghost.movement.direction)
            {
                index++;
                if (index >= node.availableDirections.Count && node.availableDirections.Count > 1)
                {
                    index = 0;
                }
            }
            this.ghost.movement.SetDirection(node.availableDirections[index]);
        }
    }

}
