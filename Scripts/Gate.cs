using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public int sceneBuildIndex;
    
    public Vector3 teleportPosition = new Vector3(5f, 2f, 0f);

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
        
            other.GetComponent<PlayerMovement>().SetSpawnPosition(teleportPosition);
            
          
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

            
        }
    }
}
