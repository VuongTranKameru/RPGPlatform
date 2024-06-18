using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bulletPrefab;
    public float timer;
    bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;

        if(timer > 2)
        {
            timer = 0;
           Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab,bulletPos.position,Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
}
