using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    
    public int gold;

    private void Awake()
    {
        instance = this;
    }

    public void CollectGold(int coin)
    {
        gold += coin;
    }
}
