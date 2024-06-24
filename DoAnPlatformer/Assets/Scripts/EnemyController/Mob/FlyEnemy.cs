using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingpoint;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if(chase == true) Chase();
        else ReturnStartPoint();
        Flip();
    }
    public void Chase()
    {
        transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, player.transform.position) <= 0.5f)
        {
            //change speed,shoot,animation
        }
        else
        {

        }
    }
    public void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position,startingpoint.position,speed*Time.deltaTime);
    }
    public void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
