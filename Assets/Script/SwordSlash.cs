using UnityEngine;

public class SwordSlash : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
    public int damage = 34;

    public Rigidbody2D rb;
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
       Destroy(gameObject, 6f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
        }
    }
    

    void Update()
    {
        
    }
}
