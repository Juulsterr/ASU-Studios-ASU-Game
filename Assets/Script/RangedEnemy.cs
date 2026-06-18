using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public Rigidbody2D target;
    public float speed = 2.4f;
    private bool canShoot = true;
    public Transform firePoint;
    public GameObject shootDarkEnergy;
    private Rigidbody2D rb;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         target = GameObject.FindGameObjectWithTag("Player")
         .GetComponent<Rigidbody2D>();
        StartCoroutine(StartShootCooldown());
    }
    void FixedUpdate()
    {
        if(target != null)
        {
            if(Vector2.Distance(target.position, transform.position) >= distanceToStop)
            {
                FollowPlayer();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && Vector2.Distance(target.position, transform.position) <= distanceToStop)
        {
            StartCoroutine(ShootCooldown());
            Shoot();
        }
    }
     void FollowPlayer()
    {
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
