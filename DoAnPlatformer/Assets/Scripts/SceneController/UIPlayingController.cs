using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayingController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject InventoryCanvas;
    bool checkPause = false;

    void Start()
    {
        // close inventory panel at the begining of the game
        PauseMenu.SetActive(false);
        InventoryCanvas.SetActive(false);
    }

    void Update()
    {
        OptionMenuKeyButton();

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!checkPause)
                checkPause = true;
            else checkPause = false;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventoryButton();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void PlayGame()
    {
        Time.timeScale = 1f;
    }

    void OptionMenuKeyButton()
    {
        if (Input.GetKeyDown(KeyCode.P) && !PauseMenu.activeInHierarchy)
        {
            OptionButton();
        }

        if (Input.GetKeyDown(KeyCode.P) && checkPause)
        {
            ContinueButton();
        }
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

    public void OpenInventoryButton()
    {
        InventoryCanvas.SetActive(true);
        PauseGame();
        Inventory.instance.ClearSelectedItemWindow();
    }

    public void CloseInventoryButton()
    {
        InventoryCanvas.SetActive(false);
        PlayGame();
    }
}
