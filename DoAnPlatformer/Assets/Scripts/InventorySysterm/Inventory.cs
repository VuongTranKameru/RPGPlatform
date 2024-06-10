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

        ClearSelectedItemWindow();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }
    }

    public void AddItem(ItemData item)
    {
        if(item.canStack){
            ItemSlot slotToStackTo = GetItemStack(item);

            if(slotToStackTo != null){
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }
        }

        ItemSlot emptySlot = GetEmptySlot();
        
        if(emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }

        ThrowItem(item);
    }

    public void ThrowItem(ItemData item)
    {
        // spawn item at position
        Instantiate(item.dropPrefab, dropPosition.position, dropPosition.rotation);
    }

    public void UpdateUI()
    {
        // loop and through all the slots
        for(int x = 0; x < slots.Length; x++)
        {
            //if there is item inside
            if(slots[x].item != null)
            {
                //set that item
                uiSlots[x].Set(slots[x]);
            }
            else
            {
                //if there is not item inside of that slot clear that slot
                uiSlots[x].Clear();
            }
        }
    }

    ItemSlot GetItemStack(ItemData item)
    {
        for(int x = 0 ; x < slots.Length; x++)
        {
            if(slots[x].item == item && slots[x].quantity < item.maxStackAmount)
            {
                return slots[x];
            }
        }
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for(int x = 0 ; x < slots.Length; x++)
        {
            if(slots[x].item == null)
            {
                return slots[x];
            }
        }

        return null;
    }

    public void SelectItem(int index)
    {
        if(slots[index].item == null)
        {
            return;
        }

        selectedItem = slots[index];
        selectedItemIndex -= index;

        selectedItemName.text = selectedItem.item.displayName;
        selectedItemDescription.text = selectedItem.item.description;

        selectedItemstatName.text = string.Empty;
        selectedItemsStatValue.text = string.Empty;

        for(int x = 0; x < selectedItem.item.consumables.Length; x++)
        {
            selectedItemstatName.text += selectedItem.item.consumables[x].type.ToString() + "\n";
            selectedItemsStatValue.text += selectedItem.item.consumables[x].value.ToString() + "\n";
        }

        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !uiSlots[index].equipped);
        UnEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && uiSlots[index].equipped);
        dropButton.SetActive(true);

    }

    void ClearSelectedItemWindow()
    {
        selectedItem = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemstatName.text = string.Empty;
        selectedItemsStatValue.text = string.Empty;
        useButton.SetActive(false);
        equipButton.SetActive(false);
        UnEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    public void OnUseButton()
    {
        if(selectedItem.item.type == ItemType.Consumable){
            for(int x = 0; x < selectedItem.item.consumables.Length; x++)
            {
                switch (selectedItem.item.consumables[x].type){
                    case ConsumableType.Health: HealthManager.instance.Heal(selectedItem.item.consumables[x].value); 
                    break;
                   // case ConsumableType.Magic : MacgicManager.instance.Heal(selectedItem.item.consumables[x].value); break;
                }
            }
        }

        RemoveSelectedItem();
    }

    public void OnEquipButton()
    {
        
    }

    void UnEquip(int index)
    {
        uiSlots[index].equipped = false;
        EquipManager.instance.Unequip();
        UpdateUI();

        if(selectedItemIndex == index)
        {
            SelectItem(index);
        }
    }

    public void OnUnequipButton()
    {
        UnEquip(selectedItemIndex);
    }

    public void OnDropButton()
    {
        ThrowItem(selectedItem.item);
        RemoveSelectedItem();
    }

    void RemoveSelectedItem()
    {
        selectedItem.quantity -= 1;

        if(selectedItem.quantity == 0)
        {
            if(uiSlots[selectedItemIndex].equipped == true)
            {
                UnEquip(selectedItemIndex);
            }

            selectedItem.item = null;
            ClearSelectedItemWindow();
        }

        UpdateUI();
    }

    public void RemoveItem(ItemData item)
    {

    }

    public bool HasItem(ItemData item, int quantity)
    {
        return false;
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
        ClearSelectedItemWindow();
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(false);
    }
}

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}
