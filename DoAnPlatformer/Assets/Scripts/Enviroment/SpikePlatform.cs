using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikePlatform : MonoBehaviour
{
    TilemapCollider2D hitBox;
    int spikeDamg = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if player step on
        if (collision.CompareTag("Player"))
        {
            HealthManager.instance.TakeDamage(spikeDamg);
        }
    }
}
