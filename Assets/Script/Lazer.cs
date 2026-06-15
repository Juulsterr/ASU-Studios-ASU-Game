using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 34;

    public Rigidbody2D rb;
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
       Destroy(gameObject, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit!");
            Destroy(gameObject);
        }
    }
    

    void Update()
    {
        
    }

}