using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    bool isFacingRight;
    float horizontal;

    Rigidbody2D myRB;
    SpriteRenderer sRender;
    Animator anim;

    private float JumpSpeed = 15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Jump();
        PlayerMovement();
        
        ResetJump(); 
        
    }
    
    public void PlayerMovement()
    {
        myRB.velocity = new Vector2(horizontal * speed , myRB.velocity.y);
        anim.SetBool("isRunning", true);  
        FlipX();
    }  

    public void FlipX()
    {
        Vector3 theScale = transform.localScale;
        transform.localScale = theScale;
         if (horizontal > 0f && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            theScale.x *= -1f;
            transform.Rotate(0f, -180f, 0f);  
        }
        else if(horizontal < 0f && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            theScale.x *= 1f;
            transform.Rotate(0f, 180f, 0f);
        }else if (horizontal == 0f){
             
            anim.SetBool("isRunning", false); 
        }
        
    }

    public void Jump(){
        if(Input.GetButtonDown("Jump")){
            anim.SetBool("isJump", true);
           
            myRB.velocity = new Vector2(myRB.velocity.x, JumpSpeed);
        }
          
        
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, 0 ,groundLayer);
    }

    private void ResetJump()
    {
        if(IsGrounded())
        {
            anim.SetBool("isJump", false);
        }
    }
        
}
