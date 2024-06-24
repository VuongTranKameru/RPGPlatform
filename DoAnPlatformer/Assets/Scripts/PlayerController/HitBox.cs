using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            //other.GetComponent<IDamageable>().TakeDamage(FindObjectOfType<EquipWeapond>().dameToEnemy);
        }
    }
}
