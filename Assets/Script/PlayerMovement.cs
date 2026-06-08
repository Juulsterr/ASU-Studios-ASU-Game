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

    [Header("Shield")]
    private bool shielded;
    [SerializeField] private GameObject shield;
    public int health = 100;
    [Range(0, 100)] [SerializeField] private float shieldTimer;
    public float noShieldTime = 30f;
    public float shieldTime = 30f;

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
        shielded = false;
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        CheckShield();
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


        // if (shieldTimer == 0)
        // {
        //     shieldTimer += shieldTime * Time.deltaTime;
        // }
    } 

    void CheckShield()
    {
        if (Input.GetMouseButton(1) &&! shielded)
        {
            shield.SetActive(true);
            shielded = true;

            Invoke("NoShield", 3f);
        }
    }

    public void NoShield()
    {
        // shieldTimer = 0;
        shield.SetActive(false);
        shielded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy1")
        {

            if (!shielded)
            {
                health -= 25;
                Debug.Log(health);
                
            }
            // if (health <= 0)
            // {
            //     Die();
            // }
        }

}
}
