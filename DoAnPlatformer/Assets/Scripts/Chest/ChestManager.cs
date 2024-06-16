using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    private bool isPlayerInRange;
    public ItemData[] dropGift;
    public int dropCount = 1;
    Animator anim;
    BoxCollider2D box;
    public Transform dropPosition;

    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(isPlayerInRange == true)
        {
            if(Input.GetKeyDown(KeyCode.E) )
            {
                anim.SetBool("isOpenning", true);
                
                if(dropCount > 0)
                {
                    for(int x = 0; x < dropGift.Length; x++)
                    {
                       Instantiate(dropGift[x].dropPrefab, dropPosition.position, Quaternion.identity);
                    }
                   dropCount--;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
}
