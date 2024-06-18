using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject player;
    public float speed = 20f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        
    }
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground"))
        {
           SetAnim();
           Destroy(gameObject, 0.5f);

        }
    }

    public void SetAnim()
    {
        anim.SetBool("isCo", true);
       
    }

   




}
