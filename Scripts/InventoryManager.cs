using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public itemSlot[] itemSlots;

    public ItemSO[] itemSOs;





    void Awake()
    {
        
        if (FindFirstObjectByType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory") && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if (Input.GetButtonDown("Inventory") && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public bool UseItem(string itemName)
    {
        for (int i =0; i< itemSOs.Length; i++)
        {
            if(itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }
            
        }
        return false;
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite,string itemDescription )
    {
        Debug.Log("itemName = "+ itemName + ", quantity = " + quantity + ", itemSprite = " + itemSprite);
        for (int i = 0; i<itemSlots.Length; i++)
        {
            if(itemSlots[i].isFull == false && itemSlots[i].itemName == itemName || itemSlots[i].quantity == 0 )
            {
                int leftOverItems = itemSlots[i].AddItem(itemName,quantity,itemSprite, itemDescription);
                if (leftOverItems>0)
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite,itemDescription);
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].selectedShader.SetActive(false);
            itemSlots[i].thisItemSelected = false;
        }
    }
}
