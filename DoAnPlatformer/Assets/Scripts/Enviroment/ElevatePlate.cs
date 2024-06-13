using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatePlate : MonoBehaviour
{
    ElevatePlatform mainElevator;

    private void Awake()
    {
        mainElevator = FindAnyObjectByType<ElevatePlatform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. check if player step on elevator, move up if have player
        if (collision.CompareTag("DownPlat"))
            mainElevator.movingUp = true;
    }
}
