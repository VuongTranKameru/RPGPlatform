using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;

    [Header("Health")]
    public float startingHealth;
    public float currentHealth ;

    Animator anim;
    Rigidbody2D rigid;
    BoxCollider2D hitbox;
    [SerializeField] AudioSource auHit;

    void Start()
    {
        instance = this;

        anim = gameObject.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();

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
        {
            auHit.Play();
            Debug.Log("wgy");
        }
        // if health reach to zero we call the die function
        if (currentHealth == 0)
        {
            anim.SetTrigger("die");
            hitbox.enabled = false;
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
