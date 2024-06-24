using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    
    public int gold;
    internal int coinPoint;

    private void Awake()
    {
        instance = this;
        coinPoint = gold;
    }

    public void CollectGold(int coin)
    {
        gold += coin;
        coinPoint += coin;
    }
}
