using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int damage;
    public PlayerHealth plh;
    public Movement player;
    public ses sess;
    private bool hasCollided = false;
    private Collider2D coldusman;
   
    
    private void Start()
    {
        coldusman = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(!hasCollided && collision.gameObject.tag == ("hero"))
        {
            player.KBCounter = player.KBTotalTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                player.KnockFromRight = true;
            }
            if(collision.transform.position.x > transform.position.x)
            {
                player.KnockFromRight = false;
            }              
            plh.TakeDamage(damage);
            sess.karakterhasar();
            hasCollided = true;
            ResetCollision();
            
        }
    }
    
       public void ResetCollision()
    {

        hasCollided = false;
    } 

        public void Death(){
            Destroy(gameObject);
        }
       
}
