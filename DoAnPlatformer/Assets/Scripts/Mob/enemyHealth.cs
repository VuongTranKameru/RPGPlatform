using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0, startingHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(Invunerability());
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
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 8, false);
    }
}
