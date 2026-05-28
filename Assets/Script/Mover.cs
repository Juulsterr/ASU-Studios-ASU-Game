using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.4f;
    public Rigidbody2D target;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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
        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            target.position,
            speed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);
    }
}