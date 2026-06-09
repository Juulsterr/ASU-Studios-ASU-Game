using UnityEngine;

public class BossFighting : MonoBehaviour
{
    private bool canSlash = true;
    public Transform firePoint;
    public GameObject swordSlash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartShootCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (canSlash)
        {
            StartCoroutine(ShootCooldown());
            Shoot();
        }
    }

     void Shoot()
    {
      Instantiate(swordSlash, firePoint.position, firePoint.rotation); 
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
 
        yield return new WaitForSeconds(5f);
 
        canSlash = true;
    }
}
