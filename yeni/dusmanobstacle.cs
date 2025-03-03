using UnityEngine;

public class dusmanobstacle : MonoBehaviour
{

   

    // Update is called once per frame
    void Update()
    {
          
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("silecek"))
        {
            
            Destroy(gameObject);
        

        }
        
    }
}
