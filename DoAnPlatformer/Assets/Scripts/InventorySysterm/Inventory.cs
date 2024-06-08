using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform dropPosition;
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;
    [Header("Selecting Items")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName, selectedItemDescription,selectedItemstatName,selectedItemsStatValue;
    public GameObject useButton, equipButton, UnEquipButton, dropButton;

    private int currentequipIndex;
    
    public static Inventory instance;
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // close inventory panel at the begining of the game
        inventoryPanel.SetActive(false);

        // get access to itemSlots list because we dont attached any script to them
        slots = new ItemSlot[uiSlots.Length];

        // initialize the slots (loop through all slots and set them up)
        for(int x = 0; x < slots.Length; x++)
        {
            slots[x] = new ItemSlot();//Set our Slots
            uiSlots[x].index = x;//index of our slots is x
            // Clear the slot mean holding no item
            uiSlots[x].Clear();
        }
    }

    
    void Update()
    {
        
    }
}

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}
