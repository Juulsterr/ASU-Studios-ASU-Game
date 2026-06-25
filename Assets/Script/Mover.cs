using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D target;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // Player Rigidbody2D zoeken
        target = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        // Richting naar speler bepalen
        Vector2 direction = (target.position - rb.position).normalized;

        // Juiste animatie afspelen
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontale beweging
            if (direction.x > 0)
            {
                animator.Play("RunRightOnryo");
            }
            else
            {
                animator.Play("RunLeftOnryo");
            }
        }
        else
        {
            // Verticale beweging
            if (direction.y > 0)
            {
                animator.Play("RunUpOnryo");
            }
            else
            {
                animator.Play("RunDownOnryo");
            }
        }

        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            target.position,
            speed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);
    }
}