using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {
    Resource,
    Equipable,
    Consumable
}

public enum ConsumableType
{
    Health,
    Magic
}

[CreateAssetMenu(fileName = "Item", menuName = "NewItem")]
public class ItemData : ScriptableObject 
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable info")]
    public ItemDataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;

}