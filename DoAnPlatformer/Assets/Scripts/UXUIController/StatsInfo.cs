using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsInfo : MonoBehaviour
{
    MoneyManager moneyInfo;

    [SerializeField] GameObject statusWindow;
    [SerializeField] TMP_Text hpMax, hpCur, damge, jump, money;
    
    void Start()
    {
        moneyInfo = FindAnyObjectByType<MoneyManager>();
    }

    void Update()
    {
        if (statusWindow.activeInHierarchy)
        {
            hpMax.text = HealthManager.instance.maxHealth.ToString("0");
            hpCur.text = HealthManager.instance.currentHealth.ToString("0") + "/";
            CheckDamage();
            jump.text = "x" + (PlayerController.instance.jumpCount + 1).ToString("0");
            money.text = moneyInfo.gold.ToString("0") + "$";
        }
    }

    void CheckDamage()
    {
        if (EquipManager.instance.currentEquip != null)
        {
            damge.text = ("" + EquipWeapond.instance.damgeStats.ToString()).ToString();
        }
        else
        {
            damge.text = "0";
        }
    }
}
