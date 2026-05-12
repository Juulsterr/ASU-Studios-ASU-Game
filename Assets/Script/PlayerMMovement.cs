using UnityEngine;
 
public class PlayerMMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 2.5f;
    public float sprintSpeed = 5f;
 
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 movement;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        // Input ophalen
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
 
        // Zorgt dat diagonaal niet sneller gaat
        moveInput = moveInput.normalized;
 
        // Sprint check
        float currentSpeed = Input.GetKey(KeyCode.LeftShift)
            ? sprintSpeed
            : moveSpeed;
 
        movement = moveInput * currentSpeed;
    }
 
    void FixedUpdate()
    {
        // Smooth movement
        rb.linearVelocity = movement;
    }
}