using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Vector2 moveDirection;


    private Animator animator;

    private Vector3 spawnPosition; 

    void Start()
    {
       
        animator = GetComponent<Animator>();
        
       
        spawnPosition = transform.position;

        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
 
        transform.position = spawnPosition;  
    }

    void Update()
    {
       
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");  

        moveDirection = new Vector2(moveX, moveY).normalized;

       
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

     
        if (moveDirection.magnitude > 0)
        {
        
            animator.SetBool("isMoving", true);

        
            if (moveDirection.x > 0)
            {
               
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveDirection.x < 0)
            {
               
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
           
            animator.SetBool("isMoving", false);
        }
    }

   
    public void SetSpawnPosition(Vector3 newPosition)
    {
        spawnPosition = newPosition; 
    }
}
