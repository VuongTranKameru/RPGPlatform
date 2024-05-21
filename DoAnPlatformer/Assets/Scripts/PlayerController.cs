using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D myRB;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2 (horizontal * speed, 0);
    }


}
