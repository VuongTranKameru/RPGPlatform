using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    internal static Inventory instance;
    UIInventory uInven;

    public Transform dropPosition;
    //public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;

    [Header("Selecting Items")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    //public TMP_Text selectedItemName, selectedItemDescription, selectedItemStatName, selectedItemStatValue;
    //public GameObject useButton, equipButton, UnEquipButton, dropButton;
    [SerializeField] AudioSource auSrc;
    [SerializeField] AudioClip auUseButton, auEquipButton, auUnequipButton, auDropButton;

    private int currentequipIndex;
    
    private void Awake()
    {
        instance = this;
        uInven = FindAnyObjectByType<UIInventory>();
        
    }

    void Start()
    {
        // get access to itemSlots list because we dont attached any script to them
        slots = new ItemSlot[uInven.uitemSlots.Length];

        // initialize the slots (loop through all slots and set them up)
        for(int x = 0; x < slots.Length; x++)
        {
            slots[x] = new ItemSlot();//Set our Slots
            uInven.uitemSlots[x].index = x;//index of our slots is x
            // Clear the slot mean holding no item
            uInven.uitemSlots[x].Clear();
        }

        ClearSelectedItemWindow();
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
                uInven.uitemSlots[x].Set(slots[x]);
            }
            else
            {
                //if there is not item inside of that slot clear that slot
                uInven.uitemSlots[x].Clear();
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
        selectedItemIndex = index;

        uInven.itemName.text = selectedItem.item.displayName;
        uInven.itemDes.text = selectedItem.item.description;

        uInven.itemStatName.text = string.Empty;
        uInven.itemStatValue.text = string.Empty;

        for(int x = 0; x < selectedItem.item.consumables.Length; x++)
        {
            uInven.itemStatName.text += selectedItem.item.consumables[x].type.ToString() + "\n";
            uInven.itemStatValue.text += selectedItem.item.consumables[x].value.ToString() + "\n";
        }

        uInven.useBtn.SetActive(selectedItem.item.type == ItemType.Consumable);
        uInven.equipBtn.SetActive(selectedItem.item.type == ItemType.Equipable && !uInven.uitemSlots[index].equipped);
        uInven.unequipBtn.SetActive(selectedItem.item.type == ItemType.Equipable && uInven.uitemSlots[index].equipped);
        uInven.dropBtn.SetActive(true);
    }

    public void ClearSelectedItemWindow()
    {
        selectedItem = null;
        uInven.itemName.text = string.Empty;
        uInven.itemDes.text = string.Empty;
        uInven.itemStatName.text = string.Empty;
        uInven.itemStatValue.text = string.Empty;
        uInven.useBtn.SetActive(false);
        uInven.equipBtn.SetActive(false);
        uInven.unequipBtn.SetActive(false);
        uInven.dropBtn.SetActive(false);
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
        auSrc.PlayOneShot(auUseButton);

        RemoveSelectedItem();
    }

    public void OnEquipButton()
    {
        if(uInven.uitemSlots[currentequipIndex].equipped)
        {
            UnEquip(currentequipIndex);
        }

        uInven.uitemSlots[selectedItemIndex].equipped = true;
        currentequipIndex = selectedItemIndex;
        EquipManager.instance.EquipNew(selectedItem.item);
        auSrc.PlayOneShot(auEquipButton);

        UpdateUI();
        SelectItem(selectedItemIndex);
    }

    void UnEquip(int index)
    {
        uInven.uitemSlots[index].equipped = false;
        EquipManager.instance.Unequip();
        UpdateUI();
        auSrc.PlayOneShot(auUnequipButton);

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
        auSrc.PlayOneShot(auDropButton);
        ThrowItem(selectedItem.item);
        RemoveSelectedItem();
    }

    void RemoveSelectedItem()
    {
        selectedItem.quantity -= 1;

        if(selectedItem.quantity == 0)
        {
            if(uInven.uitemSlots[selectedItemIndex].equipped == true)
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
}

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}
