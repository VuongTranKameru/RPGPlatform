using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    internal static PlayerController instance;

    public float speed = 10f;
    bool isFacingRight;
    float horizontal;
    [SerializeField] internal int jumpCount;
    int jumpBuff = 0;

    bool playSound;
    Rigidbody2D myRB;
    BoxCollider2D myBox;
    SpriteRenderer sRender;
    Animator anim;

    private float JumpSpeed = 15f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] AudioSource runsSound;
    [SerializeField] AudioClip jumpSound;

    public bool standStillWhileTalk = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myBox = GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
    }
 
    void Update()
    {
        if (!standStillWhileTalk) //khi noi chuyen voi npc
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            Jump();
            PlayerMovement();

            ResetJump();
        }
        else
        {
            myRB.velocity = Vector2.zero;
        }

        if (HealthManager.instance.currentHealth == 0)
            StartCoroutine(DeadAnim());
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
            
        }
        else if (horizontal == 0f)
        {
            anim.SetBool("isRunning", false); 
            runsSound.Stop();
        }
    }

    public void Jump(){
        if(Input.GetButtonDown("Jump") && jumpCount > 0){
            jumpCount -= 1;
            anim.SetBool("isJump", true);
            myRB.velocity = new Vector2(myRB.velocity.x, JumpSpeed);
            AudioSource.PlayClipAtPoint(jumpSound, Camera.main.transform.position);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheck.position, Vector2.down, 1 ,groundLayer);
    }

    void ResetJump()
    {
        if(IsGrounded())
        {
            anim.SetBool("isJump", false);
            jumpCount = 1 + jumpBuff;
        }
    }
    
    //for item
    public int JumpMore(float buffIn)
    {
        jumpBuff = ((int)buffIn);
        return jumpBuff;
    }

    internal IEnumerator DeadAnim()
    {
        myBox.enabled = false;
        myRB.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        HealthManager.instance.Die();
    }
}
