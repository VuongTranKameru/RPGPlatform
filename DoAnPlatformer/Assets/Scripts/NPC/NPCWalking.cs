using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    SpriteRenderer npcSr;
    Rigidbody2D rb;
    public float speed;

    public bool leftToRight = true, stopToSpeak;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        npcSr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PointA"))
            leftToRight = false;

        if (collision.CompareTag("PointB"))
            leftToRight = true;

        if (collision.CompareTag("Player") && stopToSpeak)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            stopToSpeak = false;
        }
    }

    public Transform Direction()
    {
        Debug.Log(gameObject.transform.position);
        return gameObject.transform;
    }

    public void WalkingToRight()
    {
        rb.velocity = new Vector2(speed, 0); 
        npcSr.flipX = false;
    }

    public void WalkingToLeft()
    {
        rb.velocity = new Vector2(-speed, 0);
        npcSr.flipX = true;
    }
}
