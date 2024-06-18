using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float timer;


    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2)
        {
            timer = 0;
           Shoot();
        }
    }

    public void Shoot()
    {
         Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);   
    }
   
}
