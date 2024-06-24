using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamge : MonoBehaviour
{
    public float dameToPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag ==  "Player")
        {
            HealthManager.instance.TakeDamage(dameToPlayer);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            HealthManager.instance.TakeDamage(dameToPlayer);
        }
    }
}
