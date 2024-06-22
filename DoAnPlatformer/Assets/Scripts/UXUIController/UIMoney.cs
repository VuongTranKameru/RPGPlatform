using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    internal static UIMoney instance;

    public TextMeshProUGUI goldText;

    private void Awake()
    {
        instance = FindAnyObjectByType<UIMoney>();
    }

    private void OnEnable()
    {
        UpdateGold();
    }

    public void UpdateGold()
    {
        goldText.text = MoneyManager.instance.gold.ToString() + "$";
    }
}
