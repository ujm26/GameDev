using UnityEngine;
using UnityEngine.UIElements;

public class ziplaatis : MonoBehaviour
{
    public Animator anim;
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("mermi"))
        {
            anim.SetBool("havaatisi",true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("mermi"))
        {
            anim.SetBool("havaatisi",false);
        }
        
        
    }
}
