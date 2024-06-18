using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, ItemData item)
    {
        Transform trasnform = Instantiate(ItemAsset.Instance.pfItemWorld,position,Quaternion.identity);


        return null;
    }
    private ItemData item;
    public void SetItem(ItemData item)
    {
        this.item = item;
    }
}
