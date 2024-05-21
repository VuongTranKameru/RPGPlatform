using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D myRB;
    SpriteRenderer sRender;
    bool isFacingRight;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    
    }
 
    void Update()
    {
        PlayerMovement();
    }
    

    public void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        myRB.velocity = new Vector2(horizontal * speed , 0);
        if (horizontal > 0 && isFacingRight)
        {
            FlipX();
        }
        else if(horizontal < 0 && !isFacingRight)
        {
            FlipX();
        }
    }  
    protected void FlipX()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
        
}
