using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    private bool isPlayerInRange;
    public ItemData[] dropGift;
    private int dropCount = 1;
    public Transform dropPosition;

    Animator anim;
    [SerializeField] AudioClip auOpen;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(isPlayerInRange == true)
        {
            if(Input.GetKeyDown(KeyCode.E) )
            {
                anim.SetBool("isOpenning", true);
                AudioSource.PlayClipAtPoint(auOpen, Camera.main.transform.position);
                
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
