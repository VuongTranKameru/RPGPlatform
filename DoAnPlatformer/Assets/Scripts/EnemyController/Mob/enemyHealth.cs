using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    public static EnemyHealth instance;
    [SerializeField] GameObject enemyDamg;

    [Header("Health")]
    public float startingHealth;
    public float currentHealth ;

    Animator anim;
    Rigidbody2D rigid;
    
    void Start()
    {
        instance = this;

        anim = gameObject.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        enemyDamg = FindAnyObjectByType<GameObject>();

        currentHealth = startingHealth;
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
            anim.SetTrigger("die");
            enemyDamg.SetActive(false);
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;

            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        /*EnemyDrop.instance.DropFromEnemy();
        Destroy(gameObject);*/
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
