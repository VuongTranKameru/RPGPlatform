using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    BossSkill skill;

    [Header("Health")]
    public float startingHealth;
    public float currentHealth;

    Rigidbody2D rigid;
    BoxCollider2D hitbox;
    Animator anim;
    [SerializeField] AudioSource auHit, auScream;

    SpriteRenderer sprite;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        skill = FindAnyObjectByType<BossSkill>();

        currentHealth = startingHealth;
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("PlayerAttack"))
            ReceiveDamage(EquipWeapond.instance.damgeStats);
    }

    public void ReceiveDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0.0f);

        if (currentHealth > 0)
            auHit.Play();
        // if health reach to zero we call the die function
        if (currentHealth == 0)
        {
            hitbox.enabled = false;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;

            anim.SetTrigger("die");
            auScream.Play();

            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        
        StartCoroutine(FadeAway(sprite));
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }

    IEnumerator FadeAway(SpriteRenderer spr)
    {
        Color transparent = spr.color;
        
        while (transparent.a > 0f)
        {
            transparent.a -= Time.deltaTime / 1f;
            spr.color = transparent;

            Debug.Log(transparent.a);

            if (transparent.a <= 0f)
                transparent.a = 0f;

            yield return null;
        }

        spr.color = transparent;
    }
}
