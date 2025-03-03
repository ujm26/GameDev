
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahnebir : MonoBehaviour
{
    public int scenebuilding;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "hero")
        {
            
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);   
            
        }

    }
    

}
