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

    void Update()
    {
        
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("Scene0-Town");
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
