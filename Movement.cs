using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
   public Rigidbody2D rb;
   public int HealthMax = 10;
    public int health;
    private float yon;
    public float speed = 4f;
    public bool isGrounded;
    public float jumpForce = 8f;
    private Animator anim;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;
    public PlayerHealth playhealth;

    public platform platform;

 



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = HealthMax;
    }

    void Update()
    {
    
        yon = Input.GetAxis("Horizontal");

    
        if (isGrounded)
        {
            
            anim.SetBool("isWalking", yon >0.3 || yon <-0.3);
        
            anim.SetBool("isFalling", false);
        }
        else
        {
            anim.SetBool("isWalking", false); 
    
       
            if (rb.linearVelocity.y < 0)
            {
                anim.SetBool("isFalling", true); 
            }
            
        }

        
    
   
        if (yon > 0)
        {
            transform.localScale = new Vector3(2, 2, 1); 
        }
        else if (yon < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1); 
        }

      
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

      
        anim.SetBool("yerdeMi", isGrounded);
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("yer") || collision.gameObject.CompareTag("plat"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("plat"))
        {
            
            Vector2 platformDirection = rb.transform.right; 
            float speed = platform.MoveSpeed; 
            Vector2 newVelocity = platformDirection * speed; 

          
            rb.linearVelocity = newVelocity; 
        }
    }
    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("yer") || collision.gameObject.CompareTag("plat"))
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
      
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        anim.SetBool("Jump", true);

    }
    void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            rb.linearVelocity = new Vector2(yon * speed, rb.linearVelocity.y);

        }
        else
        {
            if (playhealth.health <= 0)
            {
                
            }
            else
            {
                if (KnockFromRight)
            {
                rb.linearVelocity = new Vector2(-KBForce,KBForce/16);
                
            }
            if (KnockFromRight == false)
            {
                rb.linearVelocity = new Vector2(KBForce,KBForce/16);
                
            }
            KBCounter -= Time.deltaTime;
            }
            
    }

    

}
}
