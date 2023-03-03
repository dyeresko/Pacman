using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections;

    private void Start()
    {
        availableDirections = new List<Vector2>();
        CheckIfAvailableDirection(Vector2.up);
        CheckIfAvailableDirection(Vector2.down);
        CheckIfAvailableDirection(Vector2.left);
        CheckIfAvailableDirection(Vector2.right);
    }

    private void CheckIfAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.5f, this.obstacleLayer);
        if (hit.collider == null)
        {
            availableDirections.Add(direction);
        }
    }
}
