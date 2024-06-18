using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIOpenNpc : MonoBehaviour
{
    public bool playerInRange;
     public GameObject shopWindow;

    // Start is called before the first frame update
    void Start()
    {
       shopWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(playerInRange == true)
        {
            OpenShopWindow();
        }
    }

    public void OpenShopWindow()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            shopWindow.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void CloseShopWindow()
    {
        shopWindow.SetActive(false);
        Time.timeScale = 1f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}
