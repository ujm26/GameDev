using UnityEngine;
using UnityEngine.SceneManagement;


public class Item : MonoBehaviour
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    public int quantity;
    [SerializeField]
    public Sprite sprite;

    [TextArea]
    [SerializeField]
    public string itemDescription;

    private InventoryManager inventoryManager;


    public bool sahnebir= false;
    public bool sahneiki = false;
    
    
    void Awake()
    {
            if (PlayerPrefs.GetInt(itemName + "_dropped", 0) == 1)
        {
            PlayerPrefs.SetInt(itemName + "_dropped", 0);
                  
        }
    }
    

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();


        
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            sahneiki = false;
            sahnebir = true;
            
        }
        else if (SceneManager.GetActiveScene().name == "Ev")
        {
            sahnebir = false;
            sahneiki = true;
            
        }
  
       
        if (sahnebir == true)
        {
            if (PlayerPrefs.GetInt(itemName + "_collected", 0) == 1 && PlayerPrefs.GetInt(itemName + "_sahnebir", 0) == 1 )
            {
                if (PlayerPrefs.GetInt(itemName + "_dropped", 0) == 1)
                {
 
                    gameObject.SetActive(true);
                    PlayerPrefs.Save();
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("a");
                }
                
                

            }
        }
        else if (sahneiki == true)
        {
            if (PlayerPrefs.GetInt(itemName + "_collected", 0) == 1 && PlayerPrefs.GetInt(itemName + "_sahneiki", 0) == 1 )
            {
                if (PlayerPrefs.GetInt(itemName + "_dropped", 0) == 1)
                {
                    gameObject.SetActive(true);
                    PlayerPrefs.SetInt(itemName + "_dropped", 0);
                    PlayerPrefs.Save();
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("a");
                }
                
                

            }
        }
        
        else
        {
            gameObject.SetActive(true); 
            Debug.Log("c");
        }
    }



    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);

            // Eğer item tamamen alındıysa, objeyi devre dışı bırak ve PlayerPrefs'e kaydet
            if (leftOverItems <= 0)
            {
                if(sahnebir == true)
                {
                    PlayerPrefs.SetInt(itemName + "_collected", 1); // Item toplandığını kaydediyoruz
                    PlayerPrefs.SetInt(itemName + "_sahnebir", 1); // Item toplandığını kaydediyoruz
                    PlayerPrefs.Save(); // PlayerPrefs'i kaydediyoruz  
                    Destroy(gameObject); // Objeyi yok et
                    Debug.Log("e");
                   
                }
                else if (sahneiki == true)
                {
                    PlayerPrefs.SetInt(itemName + "_collected", 1); // Item toplandığını kaydediyoruz
                    PlayerPrefs.SetInt(itemName + "_sahneiki", 1); // Item toplandığını kaydediyoruz
                    PlayerPrefs.Save(); // PlayerPrefs'i kaydediyoruz  
                    Destroy(gameObject); // Objeyi yok et
                    Debug.Log("d");
                    
                }
                              
            }
            else
            {
                quantity = leftOverItems;
            }
        }
    }
}
