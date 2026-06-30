using UnityEngine;

public class BossFighting : MonoBehaviour
{
    public int health = 600;
    private bool canSlash = true;
    public Transform firePoint;
    public GameObject swordSlash;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(StartShootCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (canSlash)
        {
            Debug.Log("SLASH");
            StartCoroutine(ShootCooldown());
            Shoot();
        }
    }

     void Shoot()
    {
      Instantiate(swordSlash, firePoint.position, firePoint.rotation); 
            animator.Play("Boss slash");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LightLazer")
        {
            health -= 20;
            Debug.Log(health);
        }
        
        if (health <= 0)
        {
            EnemyDie();
        }
    }
   
    private System.Collections.IEnumerator ShootCooldown()
    {
        canSlash = false;
 
        yield return new WaitForSeconds(Random.Range(5f, 10f));
 
        canSlash = true;
    }

    private System.Collections.IEnumerator StartShootCooldown()
    {
        canSlash = false;
 
        yield return new WaitForSeconds(1f);
 
        canSlash = true;
    }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
