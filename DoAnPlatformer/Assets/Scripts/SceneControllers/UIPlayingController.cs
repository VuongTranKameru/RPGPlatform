using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayingController : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

    bool checkPause = false;

    void Start()
    {

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
}
