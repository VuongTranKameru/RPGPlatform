using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatePlatform : MonoBehaviour
{
    CapsuleCollider2D boxStop;
    Rigidbody2D rigElevate;

    internal bool movingUp = false; //check with elevate plate
    bool movingDown = false;

    void Awake()
    {
        boxStop = GetComponent <CapsuleCollider2D>();
        rigElevate = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ElevatorMoveUp();
        ElevatorMoveDown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //3. check if elevator get to the destination
        if (collision.CompareTag("Ground"))
        {
            boxStop.tag = "Ground";
            movingUp = false;
        }

        //7. check if elevator get to the beginning
        if (collision.CompareTag("StopElevate"))
        {
            boxStop.tag = "Untagged";
            movingDown = false;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        //5. check if player out of elevator, player out then elevator will move down
        if (player.CompareTag("Player") && boxStop.CompareTag("Ground"))
            StartCoroutine(OutOfElevate());
    }

    void ElevatorMoveUp()
    {
        //2. elevate up
        if (movingUp)
            rigElevate.velocity = new Vector2(rigElevate.velocity.x, +5); //+1

        //4. elevate stop
        if (!movingUp)
            rigElevate.velocity = new Vector2(rigElevate.velocity.x, 0); //+1
    }

    void ElevatorMoveDown()
    {
        //6. elevate down
        if (movingDown)
            rigElevate.velocity = new Vector2(rigElevate.velocity.x, -5);

        //8. elevate return to the first place
        if (!movingDown && boxStop.CompareTag("Ground"))
            rigElevate.velocity = new Vector2(rigElevate.velocity.x, 0);
    }

    IEnumerator OutOfElevate()
    {
        yield return new WaitForSeconds(3f);
        movingDown = true;
        movingUp = false;
    }
}
