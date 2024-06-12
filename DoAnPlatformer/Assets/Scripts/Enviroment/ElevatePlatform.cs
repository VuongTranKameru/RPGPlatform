using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatePlatform : MonoBehaviour
{
    CapsuleCollider2D boxStop;
    Rigidbody2D rigElevate;

    bool movingUp = false, movingDown = false, waiting = false;

    void Awake()
    {
        boxStop = GetComponent <CapsuleCollider2D>();
        rigElevate = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingUp && !waiting)
            rigElevate.velocity = new Vector2(rigElevate.velocity.x, +5); //+1
        
        if (!movingUp)
        {
            rigElevate.velocity = new Vector2(rigElevate.velocity.x, 0); //+1
        }

        if (movingDown)
            rigElevate.velocity = new Vector2(rigElevate.velocity.x, -5);

        Debug.Log(movingDown);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            //Debug.Log("stop");
            movingUp = false;
            waiting = true;
            boxStop.tag = "Ground";
        }

        if (collision.CompareTag("DownPlat"))
        {
            //Debug.Log("fly");
            movingUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player") && boxStop.CompareTag("Ground"))
        {
            Debug.Log("check");

            StartCoroutine(OffElevate());
        }

        /*if (foot.CompareTag("DownPlat"))
        {
            StartCoroutine(OffElevate());
            waiting = false;
        }*/
    }

    IEnumerator OffElevate()
    {
        yield return new WaitForSeconds(5f);
        movingDown = true;
    }
}
