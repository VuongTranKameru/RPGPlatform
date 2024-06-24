using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public Equip currentEquip;
    public Transform weapondHolder;

    public static EquipManager instance;

    //in EquipManager
    internal int weaponPoint;
    int w1, w2, w3 = 0;

    private void Awake()
    {
        instance = this;
    }

    public void EquipNew(ItemData item)
    {
        Unequip();
        CheckEquipedWeapon(item);
        CountingWeapon(item);
        currentEquip = Instantiate(item.equipPrefab, weapondHolder).GetComponent<Equip>();
    }

    public void Unequip()
    {
        if(currentEquip != null)
        {
            Destroy(currentEquip.gameObject);
            currentEquip = null;
        }
    }

    void CheckEquipedWeapon(ItemData i)
    {
        if (i.type.ToString() == "Equipable")
        {
            if (i.name == "KnifeIron" && w1 != -1)
                w1 = 1;
            if (i.name == "SwordCopper" && w2 != -2)
                w2 = 2;
            if (i.name == "SwordSilver" && w3 != -3)
                w3 = 3;
        }
    }

    void CountingWeapon(ItemData p)
    {
        if (w1 == 1)
        {
            weaponPoint += (int)p.consumables[0].value;
            w1 = -1;
            //Debug.Log("1: " + weaponPoint);
        }

        if (w2 == 2)
        {
            weaponPoint += (int)p.consumables[0].value;
            w2 = -2;
        }

        if (w3 == 3)
        {
            weaponPoint += (int)p.consumables[0].value;
            w3 = -3;
        }
    }
}
