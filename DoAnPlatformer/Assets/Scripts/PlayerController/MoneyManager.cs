using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    UIMoney moneyShow;

    public static MoneyManager instance;
    //public TextMeshProUGUI goldText;
    public int gold;

    private void Awake()
    {
        instance = this;
        moneyShow = FindAnyObjectByType<UIMoney>();
    }

    void Update()
    {
        //Debug.Log(gold);
        

        UpdateGold();
    }

    public void UpdateGold()
    {
        moneyShow.goldText.text = gold.ToString() + "$";
    }

    public void CollectGold(int coin)
    {
        gold += coin;
    }
}
