using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ItemsBuy : MonoBehaviour
{
    [SerializeField] public ItemData itemToBuy;
    [SerializeField] public int itemCost;
    public Image itemIcon;
    [SerializeField] public TextMeshProUGUI priceText;
    [SerializeField] public AudioSource auSrc;
    
    void Start()
    {
        itemIcon.sprite = itemToBuy.icon;
        priceText.text = itemCost.ToString() + "$"; 
    }

    public void BuyItem()
    {
        if(itemCost <= MoneyManager.instance.gold)
        {
            MoneyManager.instance.gold -= itemCost;
            UIMoney.instance.UpdateGold();
            auSrc.Play();
            Inventory.instance.AddItem(itemToBuy);
        }
        else
        {
            Debug.Log("Player not enough Money to Buy");
        }
    }
}
