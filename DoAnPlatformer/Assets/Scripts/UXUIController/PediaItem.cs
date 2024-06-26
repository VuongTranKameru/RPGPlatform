using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PediaItem : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] ItemData getItem;

    [Header("Renderer")]
    [SerializeField] Image pngDetail;
    [SerializeField] TMP_Text nameTx, typeTx, desTx;

    void OnEnable()
    {
        ReadInfo();   
    }

    void ReadInfo()
    {
        pngDetail.sprite = getItem.icon;

        ColorType();
        typeTx.text = getItem.type.ToString();

        nameTx.text = getItem.displayName;
        desTx.text = getItem.description;
    }

    void ColorType()
    {
        if (getItem.type.ToString() == "Resource")
            typeTx.color = Color.yellow;
        else if (getItem.type.ToString() == "Equipable")
            typeTx.color = Color.cyan;
        else if (getItem.type.ToString() == "Consumable")
            typeTx.color = Color.green;
        else
            typeTx.color = Color.white;
    }
}
