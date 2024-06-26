using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PediaMonster : MonoBehaviour
{
    [Header("Mob")]
    [SerializeField] GameObject getMob;

    [Header("Renderer")]
    [SerializeField] GameObject dropFrom;
    [SerializeField] Image pngDetail, pngIcon;
    [SerializeField] TMP_Text nameTx, typeTx, dropTx, desTx;

    void OnEnable()
    {
        ReadInfo();
    }

    void ReadInfo()
    {
        pngDetail = pngIcon;

        typeTx.color = Color.red;
        typeTx.text = "Monster";

        dropFrom.SetActive(true);
        dropTx.text = "- " + DropList();

        nameTx.text = getMob.name;
        desTx.text = DesMadeUp();
    }

    string DesMadeUp()
    {
        if (getMob.name == "Snail")
            return "A small little creature which is very dangeous despite the look, especially bad for plant. Have a steady conch.";
        
        if (getMob.name == "Boar")
            return "Agressive hunting animals, only a charge and it may torn apart piece by piece. Its meat is good, tho.";

        if (getMob.name == "Fly")
            return "A honey actually, not a fly, but it fly so named fly. Pointed sting, only cause damage at that part. Also love chasing.";

        return null;
    }

    string DropList()
    {
        if (getMob.name == "Snail")
            return "Snail Steel, Coin Small, Coin Copper";

        if (getMob.name == "Boar")
            return "Boar Horn, Coin Small, Coin Copper, Coin Gold";

        if (getMob.name == "Fly")
            return "Honey Flower, Coin Gold";

        return null;
    }
}
