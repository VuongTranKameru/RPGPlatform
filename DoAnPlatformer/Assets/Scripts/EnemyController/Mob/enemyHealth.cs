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

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    void Start()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0.0f);
       if(currentHealth > 0)
        {
            StartCoroutine(Hurt());

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
    private IEnumerator Hurt()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
    }

}
