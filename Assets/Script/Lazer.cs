using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 34;

    public Rigidbody2D rb;
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
       Destroy(gameObject, 1f);
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