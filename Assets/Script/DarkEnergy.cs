using UnityEngine;

public class DarkEnergy : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 15;

    public Rigidbody2D rb;
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
       Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
