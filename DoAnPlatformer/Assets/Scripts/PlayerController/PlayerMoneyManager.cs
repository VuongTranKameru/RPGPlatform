using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyManager : MonoBehaviour
{
    public static PlayerMoneyManager instance;
    public int gold;
    public TextMeshProUGUI goldText;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        UpdateGold();
    }
    public void UpdateGold()
    {
        goldText.text = gold.ToString() + "$";
    }
}
