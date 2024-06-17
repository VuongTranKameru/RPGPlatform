using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoneyManager : MonoBehaviour
{
    public static PlayerMoneyManager instance;
    public int gold;
    public TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGold();
    }
    public void UpdateGold()
    {
        goldText.text = gold.ToString() + "$";
    }
}
