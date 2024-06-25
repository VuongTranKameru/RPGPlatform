using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject player;
    public float speed;
    [SerializeField] int bulletdmg;

    [SerializeField] Rigidbody2D rb;
    CircleCollider2D hitbox;
    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hitbox = GetComponent<CircleCollider2D>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("isCo", true);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            hitbox.isTrigger = true;
            anim.SetBool("isCo", true);
            HealthManager.instance.TakeDamage(bulletdmg);
        }
    }

    public void SetAnim()
    {
        Destroy(gameObject);
    }

   




}
