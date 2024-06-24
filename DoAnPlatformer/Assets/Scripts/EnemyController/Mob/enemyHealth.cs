using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    public static EnemyHealth instance;
    [Header("Health")]
    [SerializeField] public float startingHealth;
    public float currentHealth ;
    private Animator anim;
    
    void Start()
    {
        instance = this;
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0.0f);
        if(currentHealth > 0)
        {
            
        }
        // if health reach to zero we call the die function
        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy is Dead");
        anim.SetTrigger("die");
        anim.ResetTrigger("die");
        /*EnemyDrop.instance.DropFromEnemy();
        Destroy(gameObject);*/
        gameObject.SetActive(false);
    }
}
