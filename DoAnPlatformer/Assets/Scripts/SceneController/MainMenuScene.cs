using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    [SerializeField] GameObject HowToPlayBoard;

    void Start()
    {
        PlayerPrefs.DeleteKey("LastScene");
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("Scene-IntroTown");
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlayButton()
    {
        HowToPlayBoard.SetActive(true);
    }

    public void HowToPlayBoardOff()
    {
        HowToPlayBoard.SetActive(false);
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
