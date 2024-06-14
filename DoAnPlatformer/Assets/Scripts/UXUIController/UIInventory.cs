using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] internal ItemSlotUI[] uitemSlots;
    [SerializeField] internal TMP_Text itemName, itemDes, itemStatName, itemStatValue;

    void ClearSelectedItemWindow()
    {
        //selectedItem = null;
        itemName.text = string.Empty;
        itemDes.text = string.Empty;
        itemStatName.text = string.Empty;
        itemStatValue.text = string.Empty;
        /*useButton.SetActive(false);
        equipButton.SetActive(false);
        UnEquipButton.SetActive(false);
        dropButton.SetActive(false);*/
    }
}
