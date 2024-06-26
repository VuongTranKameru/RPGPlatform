using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    BoxCollider2D boxStair;

    private void Awake()
    {
        boxStair = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if player step on stair
        if (collision.CompareTag("DownPlat"))
        { 
            boxStair.isTrigger = false;
            //Debug.Log("uncheck");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("touch");
        boxStair.isTrigger = true;
    }
}