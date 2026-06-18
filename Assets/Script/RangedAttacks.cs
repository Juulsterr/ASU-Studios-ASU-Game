using UnityEngine;

public class RangedAttacks : MonoBehaviour
{
    private bool canShoot = true;
    public Transform firePoint;
    public GameObject shootDarkEnergy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartShootCooldown());
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootCooldown());
            Shoot();
        }
    }

     void Shoot()
    {
      Instantiate(shootDarkEnergy, firePoint.position, firePoint.rotation); 
    }

    private System.Collections.IEnumerator ShootCooldown()
    {
        canShoot = false;
 
        yield return new WaitForSeconds(Random.Range(1f, 3f));
 
        canShoot = true;
    }

    private System.Collections.IEnumerator StartShootCooldown()
    {
        canShoot = false;
 
        yield return new WaitForSeconds(1f);
 
        canShoot = true;
    }
}
