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
       Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
    

    void Update()
    {
        
    }
}
