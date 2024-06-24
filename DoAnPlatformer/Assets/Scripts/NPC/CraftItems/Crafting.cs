using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    [Header("Item")]
    public Image itemIcon;
    [SerializeField] ItemData itemToCraft;
    [SerializeField] TMP_Text nameText;
    [SerializeField] AudioSource auCraft, auNoEnough;

    [Header("Ingredient")]
    [SerializeField] int amount;
    [SerializeField] ItemDataResource[] resources;
    [SerializeField] ItemCraftUI[] checkAmount;

    void Start()
    {
        itemIcon.sprite = itemToCraft.icon;
        nameText.text = itemToCraft.displayName;
    }

    public void CraftItem()
    {
        for (int x = 0; x < resources.Length; x++)
        {
            //dont add wrong order. check if enough resource
            if (resources[x].value > checkAmount[x].quantityNum)
            {
                auNoEnough.Play();
                Debug.Log("not enough" + resources[x].typeOfResource.name + resources[x].value + "/" + checkAmount[x].quantityNum);
                return; 
            }
        }

        //delete used resource
        for (int x = 0; x < resources.Length; x++)
        {
            checkAmount[x].quantityNum -= resources[x].value;
            checkAmount[x].quantityText.text = checkAmount[x].quantityNum.ToString();
            checkAmount[x].Check();

            //add name of resource and quantity after calculate
            Inventory.instance.RemoveUsedResource(resources[x].typeOfResource.name, checkAmount[x].quantityNum);
        }

        auCraft.Play();
        Inventory.instance.AddItem(itemToCraft);
    }
}

[System.Serializable]
public class ItemDataResource
{
    public ItemData typeOfResource;
    public int value;
}