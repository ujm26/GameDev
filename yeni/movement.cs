using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public BoxCollider2D box;

    public bool isGrounded;
    public float jumpForce;
    public float speed;
    public float hizlanma;
    public Gamemanager gameManager;
    public ShadowCaster2D shadow;
    public Animator anim;
    public int currentMoney;
    private bool doublejumpdegiskeni;

    public float zamanegilme;
    public float maxzamanegilme;
    
    public ates ates;
    public ShadowCaster2D golgeegilme;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {;
        if (speed <8)
        {
            speed += hizlanma * Time.deltaTime;
        }
        
        

        // Rigidbody2D ile hareket etmek
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y); // X ekseninde hız artır, Y eksenini sabit tut

        // Zıplama işlemi
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            anim.SetBool("jump", true); // Zıplama animasyonu
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false)
        {
            if (doublejumpdegiskeni == false)
            {
                Jump();
                doublejumpdegiskeni =true;
                anim.SetBool("dj",true);
            }
            
        }


        // Yerdeyken düşme animasyonu
        if (isGrounded)
        {
            anim.SetBool("fall", false); // Düşme animasyonunu kapat
            anim.SetBool("dj",false);
            
        }
        else
        {
            if (rb.linearVelocity.y < 0)
            {
                anim.SetBool("fall", true); // Düşme animasyonu
            }
        }


        if (Input.GetKeyDown(KeyCode.S)&& isGrounded)
        {
            box.offset = new Vector2(-3.7f,0.4f);
            box.size = new Vector2(0.5f,0.9f);
            
            ates.enabled =false;
            isGrounded = false;
            doublejumpdegiskeni =true;
            anim.SetBool("crocuh",true);
            shadow.enabled = false;
            golgeegilme.enabled =true;

            
        }
        else if (Input.GetKeyDown(KeyCode.W) )
            {
            box.offset = new Vector2(-3.7f,1.5f);
            box.size = new Vector2(0.5f,3f);
            
            ates.enabled =true;
            isGrounded = true;
            doublejumpdegiskeni =false;
            anim.SetBool("crocuh",false);
            shadow.enabled = true;
            golgeegilme.enabled =false;
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("yer"))
        {
            doublejumpdegiskeni = false;
            isGrounded = true;
            shadow.enabled = true;
            anim.SetBool("jump", false); // Zıplama animasyonu bittiğinde yere inme animasyonuna geç
        }

        if (collision.gameObject.CompareTag("dusman"))
        {
            anim.SetBool("dea",true);
        }
        if (collision.gameObject.CompareTag("levha"))
        {
            anim.SetBool("dea",true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("yer"))
        {
            isGrounded = false;
            shadow.enabled = false; // Yerden ayrıldığında gölgeyi kapat
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // Y ekseninde zıplama kuvvetini uygula
    }

    void olum()
    {
       
        gameManager.gameOver();
        Time.timeScale = 0; 
        
    }
}