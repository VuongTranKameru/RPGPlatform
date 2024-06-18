using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour,IDamageable
{
    
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth ;
    private Animator anim;
    private bool dead;

    
    void Start()
    {
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
        Destroy(gameObject);
    }
}
