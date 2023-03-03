using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    public Sprite up;
    public Sprite right;
    public Sprite left;
    public Sprite down;

    private SpriteRenderer spriteRenderer;

    private Movement movement;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.movement = GetComponentInParent<Movement>();
    }

    private void Update()
    {
        if (this.movement.direction == Vector2.up)
        {
            this.spriteRenderer.sprite = this.up;
        }
        else if (this.movement.direction == Vector2.down)
        {
            this.spriteRenderer.sprite = this.down;
        }
        else if (this.movement.direction == Vector2.left)
        {
            this.spriteRenderer.sprite = this.left;
        }
        else if (this.movement.direction == Vector2.right)
        {
            this.spriteRenderer.sprite = this.right;
        }
    }

}
