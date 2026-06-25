using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public int health = 100;
    public Rigidbody2D target;
    public float speed = 2.4f;

    private bool canShoot = true;
    public Transform firePoint;
    public GameObject shootDarkEnergy;

    private Rigidbody2D rb;
    private Animator animator;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        target = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<Rigidbody2D>();

        StartCoroutine(StartShootCooldown());
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                FollowPlayer();
            }
        }
    }

    void Update()
    {
        if (canShoot && Vector2.Distance(target.position, transform.position) <= distanceToStop)
        {
            Shoot();
            StartCoroutine(ShootCooldown());
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = (target.position - rb.position).normalized;

        // Animatie kiezen
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                animator.Play("RunRightRaiju");
            }
            else
            {
                animator.Play("RunLeftRaiju");
            }
        }
        else
        {
            if (direction.y > 0)
            {
                animator.Play("RunUpRaiju");
            }
            else
            {
                animator.Play("RunDownRaiju");
            }
        }

        Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            target.position,
            speed * Time.fixedDeltaTime
        );

        rb.MovePosition(newPos);
    }

    void Shoot()
    {
        Instantiate(shootDarkEnergy, firePoint.position, firePoint.rotation);
    }

    private System.Collections.IEnumerator ShootCooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(Random.Range(2f, 4f));

        canShoot = true;
    }

    private System.Collections.IEnumerator StartShootCooldown()
    {
        canShoot = false;

        yield return new WaitForSeconds(2f);

        canShoot = true;
    }
}