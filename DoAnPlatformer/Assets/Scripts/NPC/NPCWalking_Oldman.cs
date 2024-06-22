using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking_Oldman : MonoBehaviour
{
    [SerializeField] GameObject pointA, pointB;
    Transform currentPoint;
    NPCWalking npcWalk;

    void Start()
    {
        currentPoint = pointB.transform;
        npcWalk = FindAnyObjectByType<NPCWalking> ();
    }

    void Update()
    {
        if (currentPoint == pointB.transform)
            npcWalk.WalkingToRight();

        if (currentPoint == pointA.transform || !npcWalk.leftToRight)
            npcWalk.WalkingToLeft();

        if (Input.GetKeyDown(KeyCode.E))
            npcWalk.stopToSpeak = true;
    }
}
