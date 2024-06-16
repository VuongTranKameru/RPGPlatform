using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    bool isFacingRight;
    float horizontal;
    [SerializeField] private int jumpCount;

    bool playSound;
    Rigidbody2D myRB;
    SpriteRenderer sRender;
    Animator anim;

    private float JumpSpeed = 15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] AudioSource auSrc,runsSound;
    [SerializeField] AudioClip jumpSound;


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
            runsSound.Play();
            
        }
        else if(horizontal < 0f && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            theScale.x *= 1f;
            transform.Rotate(0f, 180f, 0f);
            runsSound.Play();
            
        }else if (horizontal == 0f){
             
            anim.SetBool("isRunning", false); 
            runsSound.Stop();
            
        }
        
    }

    public void Jump(){
        if(Input.GetButtonDown("Jump") && jumpCount > 0){
            jumpCount -= 1;
            anim.SetBool("isJump", true);
            myRB.velocity = new Vector2(myRB.velocity.x, JumpSpeed);
            auSrc.PlayOneShot(jumpSound);
        }

          
        
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, 1 ,groundLayer);
    }

    private void ResetJump()
    {
        if(IsGrounded())
        {
            anim.SetBool("isJump", false);
            jumpCount = 2;
        }
    }
        
}
