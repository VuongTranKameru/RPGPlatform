using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] internal ItemSlotUI[] uitemSlots;
    [Header("Selecting Items Information")]
    [SerializeField] internal TMP_Text itemName;
    [SerializeField] internal TMP_Text itemDes, itemStatName, itemStatValue;
    [SerializeField] internal GameObject equipBtn, unequipBtn, useBtn, dropBtn;

    public void UsingEquip()
    {
        Inventory.instance.OnEquipButton();
    }

    public void UsingUnequip()
    {
        Inventory.instance.OnUnequipButton();
    }

    public void UsingConsume()
    {
        Inventory.instance.OnUseButton();
    }

    public void UsingDrop()
    {
        Inventory.instance.OnDropButton();
    }
}
