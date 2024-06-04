using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("LastScene");
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("Scene0-Town");
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
