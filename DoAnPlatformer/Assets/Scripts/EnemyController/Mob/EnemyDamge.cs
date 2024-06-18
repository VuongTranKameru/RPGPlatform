using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamge : MonoBehaviour
{
    public float dametoPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag ==  "Player")
        {
            HealthManager.instance.TakeDamage(dametoPlayer);
        }
    }
}
