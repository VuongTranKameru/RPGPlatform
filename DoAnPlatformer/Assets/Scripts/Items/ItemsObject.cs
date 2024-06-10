using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsObject : MonoBehaviour
{
  public ItemData item;

  private void OnTriggerEnter2D (Collider2D other){
    if(other.tag == "Player"){
        // add the item in inventory

        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }
  } 
}
