using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayingController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject InventoryCanvas;
    [SerializeField] AudioSource auSrc;
    [SerializeField] AudioClip auOpenInvenButton,auPause,auUnpause;

    void Start()
    {
        // close inventory panel at the begining of the game
        PauseMenu.SetActive(false);
        InventoryCanvas.SetActive(false);
    }

    void Update()
    {
        OptionMenuKeyButton();
        InventoryMenuKeyButton();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        auSrc.PlayOneShot(auPause);
    }

    void PlayGame()
    {
        if(!PauseMenu.activeInHierarchy && !InventoryCanvas.activeInHierarchy)
            Time.timeScale = 1f;
            auSrc.PlayOneShot(auUnpause);
    }

    void OptionMenuKeyButton()
    {
        if (Input.GetKeyDown(KeyCode.P) && !PauseMenu.activeInHierarchy)
        {
            OptionButton(); 
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
            ContinueButton();
    }

    public void OptionButton()
    {
        PauseMenu.SetActive(true);
        PauseGame();
    }

    public void ContinueButton()
    {
        PauseMenu.SetActive(false);
        PlayGame();
    }

    void InventoryMenuKeyButton()
    {
        if (Input.GetKeyDown(KeyCode.I) && !InventoryCanvas.activeInHierarchy)
        {
            OpenInventoryButton();
            return;
        }

        if (Input.GetKeyDown(KeyCode.I))
            CloseInventoryButton();
    }

    public void OpenInventoryButton()
    {
        InventoryCanvas.SetActive(true);
        auSrc.PlayOneShot(auOpenInvenButton);
        Time.timeScale = 0f;
        Inventory.instance.ClearSelectedItemWindow();
    }

    public void CloseInventoryButton()
    {
        auSrc.PlayOneShot(auOpenInvenButton);
        InventoryCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
