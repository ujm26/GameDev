using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemSlot : MonoBehaviour, IPointerClickHandler
{
    // ---ITEM DATA--- ///
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite EmptySprite;

    [SerializeField]
    private int maxNumberOfItems;

    // ---ITEM SLOT--- ///
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;  

    // ---ITEM DESCRIPTION SLOT--- //
    public Image ItemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;



    public void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //Check to see if the slot is already full
        if (isFull)
            return quantity;

        //Update Name
        this.itemName = itemName;
        //Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        //Update Description
        this.itemDescription = itemDescription;
        //Update Quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
            
            //Return the LEFTOVERS  
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //Update Quantity Text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;
        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        // Eğer bu eşya seçilmişse ve miktarı 1'den fazla ise
        if (thisItemSelected && quantity > 0)
        {
            bool usable = inventoryManager.UseItem(itemName);
            if (usable)
            {
                this.quantity -= 1;  // Her kullanımda miktarı bir azaltıyoruz
                quantityText.text = this.quantity.ToString();

                if (this.quantity <= 0)
                    EmptySlot();
            }
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = itemDescription;
            ItemDescriptionImage.sprite = itemSprite;

            if (ItemDescriptionImage.sprite == null)
                ItemDescriptionImage.sprite = EmptySprite;
        }   
    }

    public void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = EmptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        ItemDescriptionImage.sprite = EmptySprite;
    }

    public void OnRightClick()
    {
         // Eğer slot boşsa, sağ tıklama işlemi yapılmasın
        if (quantity <= 0)  // Eğer slot boşsa
        {
            return;  // Sağ tıklama işlemini engelle
        }



        // Create a new item to drop
        GameObject itemToDrop = new GameObject(itemName);
        Item newItem = itemToDrop.AddComponent<Item>();
        newItem.quantity = 1;
        newItem.itemName = itemName;
        newItem.sprite = itemSprite;
        newItem.itemDescription = itemDescription;

        SpriteRenderer sr = itemToDrop.AddComponent<SpriteRenderer>();
        sr.sprite = itemSprite;

        itemToDrop.AddComponent<BoxCollider2D>();

        PlayerPrefs.SetInt(itemName + "_dropped", 1);
        PlayerPrefs.Save(); // PlayerPrefs'i kaydediyoruz

        // Set the location to be near the player
        itemToDrop.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(1.5f,0f,0);

        // Subtract the item
        this.quantity -= 1;
        quantityText.text = this.quantity.ToString();
        if (this.quantity <= 0)
            EmptySlot();
    }
}