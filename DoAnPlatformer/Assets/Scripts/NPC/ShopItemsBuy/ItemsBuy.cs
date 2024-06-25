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
    [SerializeField] public TextMeshProUGUI priceText, nameText;
    [SerializeField] public AudioSource auBuy, auNotEnough;
    
    void Start()
    {
        itemIcon.sprite = itemToBuy.icon;
        priceText.text = itemCost.ToString() + "$";
        nameText.text = itemToBuy.displayName;
    }

    public void BuyItem()
    {
        if(itemCost <= MoneyManager.instance.gold)
        {
            MoneyManager.instance.gold -= itemCost;
            UIMoney.instance.UpdateGold();
            auBuy.Play();
            Inventory.instance.AddItem(itemToBuy);
        }
        else
        {
            auNotEnough.Play();
            Debug.Log("Player not enough Money to Buy");
        }
    }
}
