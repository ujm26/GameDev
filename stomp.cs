using System.Collections;
using UnityEngine;

public class stomp : MonoBehaviour
{
    public GameObject dusman;  
    public ses sess;           
    public Animator Animation;  
    public DusmanMovement move;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "hero")
        {
            
            sess.olum();             
            Destroy(gameObject);     
            Animation.SetBool("olum", true); 
            move.MoveSpeed=0;
            Destroy(move.col);            

        }
    }

}