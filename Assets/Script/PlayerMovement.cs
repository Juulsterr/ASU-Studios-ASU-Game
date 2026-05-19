using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
   public float moveSpeed = 2.5f;
   public float sprintSpeed = 5f;
   private int distance;
   public GameObject lazer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.S);
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);

        Vector3 move = Vector3.zero;

        if (up && !down && !left && !right)
        {
            move = Vector3.up;
        }
        else if (down && !up && !left && !right)
        {
            move = Vector3.down;
        }
        else if (left && !up && !down && !right)
        {
            move = Vector3.left;
        }
        else if (right && !up && !down && !left)
        {
            move = Vector3.right;
        }

        transform.position += move * Time.deltaTime * moveSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 2.5f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * moveSpeed);

    }

}
