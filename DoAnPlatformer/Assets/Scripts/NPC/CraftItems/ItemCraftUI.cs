using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCraftUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText, quantityText, quantityNeedText;
    internal int quantityNum;

    [SerializeField] ItemData itemCraft;
    [SerializeField] ItemDataResource quantityNeed;

    private void OnEnable()
    {
        Set();
        Check();
    }

    void Set()
    {
        //set the sprite of item need to craft to icon
        icon.sprite = itemCraft.icon;
        nameText.text = itemCraft.displayName;

        //itemdata la tap hop con cua itemslot
        AmountOfSelectedResource();
    }

    public void Check()
    {
        quantityNeedText.text = quantityNeed.value.ToString();

        if (quantityNeed.value > quantityNum)
            quantityText.color = Color.red;
        else
            quantityText.color = Color.green;
    }

    void AmountOfSelectedResource()
    {
        for (int x = 0; x < ResourceAmount.instance.itemResource.Length; x++)
        {
            if (Inventory.instance.resourceSlots[x] == null)
            { 
                //khi chua pick item gi het
                quantityText.text = "0";
                quantityNum = 0;
                return; 
            }

            if (Inventory.instance.resourceSlots[x].item.displayName != nameText.text)
            {
                //khi pick item roi nhung da empty
                quantityText.text = "0";
                quantityNum = 0; 
            }
            else if (Inventory.instance.resourceSlots[x].item.displayName == nameText.text)
            {
                quantityNum = Inventory.instance.resourceSlots[x].quantity;
                quantityText.text = quantityNum.ToString("0");
                return;
            }
        }
    }
}
