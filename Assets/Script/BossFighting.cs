using UnityEngine;

public class BossFighting : MonoBehaviour
{
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

}
