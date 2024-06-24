using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public Equip currentEquip;
    public Transform weapondHolder;

    public static EquipManager instance;
    
    private void Awake()
    {
        instance = this;
    }

    public void EquipNew(ItemData item)
    {
        Unequip();
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
}
