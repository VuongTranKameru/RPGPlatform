using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayingController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject InventoryCanvas, StatusMenu;

    [Header("Audio")]
    [SerializeField] AudioSource auSrc;
    [SerializeField] AudioClip auOpenInvenButton, auPause, auUnpause, auStatus;

    void Start()
    {
        // close inventory panel at the begining of the game
        PauseMenu.SetActive(false);
        InventoryCanvas.SetActive(false);
        StatusMenu.SetActive(false);
    }

    void Update()
    {
        OptionMenuKeyButton();
        InventoryMenuKeyButton();
        StatusInfoKeyButton();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void PlayGame()
    {
        if (!PauseMenu.activeInHierarchy && !InventoryCanvas.activeInHierarchy && !StatusMenu.activeInHierarchy)
        {
            Time.timeScale = 1f;
        }
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
        auSrc.PlayOneShot(auPause);
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
        PauseGame();
        Inventory.instance.ClearSelectedItemWindow();
    }

    public void CloseInventoryButton()
    {
        InventoryCanvas.SetActive(false);
        PlayGame();
    }

    void StatusInfoKeyButton()
    {
        if (Input.GetKeyDown(KeyCode.T) && !StatusMenu.activeInHierarchy)
        {
            OpenStatsInfoPanel();
            return;
        }

        if (Input.GetKeyDown(KeyCode.T))
            CloseStatsInfoPanel();
    }

    public void OpenStatsInfoPanel()
    {
        StatusMenu.SetActive(true);
        auSrc.PlayOneShot(auStatus);
        PauseGame();
    }

    public void CloseStatsInfoPanel()
    {
        StatusMenu.SetActive(false);
        PlayGame();
    }
}
