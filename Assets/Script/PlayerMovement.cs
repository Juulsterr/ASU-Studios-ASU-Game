using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    private Rigidbody2D rb;
    public float moveSpeed = 2.5f;
    private float sprintSpeed = 5f;
    private int distance;
    public GameObject lazer;
    public float rotatationSpeed = 45f;




    [Header("Stamina")]
    [HideInInspector] public bool hasRegenerated = true;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 20f;
    public Image staminaImage;
    public float speedStaminaCost = 25f;

     [field: SerializeField]
    public float MaxStamina { get; private set; }
   
    [field: SerializeField]

    private float stamina = 0;
    public float Stamina {
        get
        {
            return stamina;
        }
        set
        {
            if(value < 0){stamina = 0;}
            else
            {
                stamina = value;
            }
        } }
 

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
        if (right)
        {
            move = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (left)
        {
            move = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (up)
        {
            move = Vector3.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (down)
        {
            move = Vector3.down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        transform.position += move * Time.deltaTime * moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Stamina -= speedStaminaCost * Time.deltaTime;

        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
            staminaRegen = 0f;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 2.5f;
            staminaRegen = 20f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);


        rb.AddForce (movement * moveSpeed);

        if(stamina <= MaxStamina - 0.01)
        {
            stamina += staminaRegen * Time.deltaTime;
        }

        staminaImage.fillAmount = stamina / 100f;

        if (stamina == 0)
        {
            moveSpeed = 2.5f;
        }

    } 
}
