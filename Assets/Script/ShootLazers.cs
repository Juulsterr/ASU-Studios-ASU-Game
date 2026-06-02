using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootLazers : MonoBehaviour
{
    [SerializeField]
 
    private bool canShoot = true;
    public Transform firePoint;
    public GameObject lazer;
    
    // Update is called once per frame
     private void Update()
    {
        
       if (Input.GetMouseButtonDown(0)&& canShoot)
        {
            StartCoroutine(ShootCooldown());
            Shoot();
        }
    }

    

    void Shoot()
    {
      Instantiate(lazer, firePoint.position, firePoint.rotation); 
    }

    private System.Collections.IEnumerator ShootCooldown()
    {
        canShoot = false;
 
        yield return new WaitForSeconds(0.5f);
 
        canShoot = true;
    }
}
