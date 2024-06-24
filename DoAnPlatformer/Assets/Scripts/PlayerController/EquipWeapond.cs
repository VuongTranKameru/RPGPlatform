using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapond : Equip
{
    public static EquipWeapond instance;

    EquipWeapond weapond;
    public int dameToEnemy;
    public int damgeStats;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        damgeStats = dameToEnemy;
    }
}
