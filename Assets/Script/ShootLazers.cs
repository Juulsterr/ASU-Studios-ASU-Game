using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootLazers : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lazer;
    
    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
      Instantiate(lazer, firePoint.position, firePoint.rotation); 
    }

    
}
