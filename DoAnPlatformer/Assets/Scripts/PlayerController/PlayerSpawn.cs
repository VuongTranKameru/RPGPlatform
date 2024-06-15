using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform playerPosition, player;

    void Awake()
    {
        player.GetComponent<PlayerController>().enabled = false;

        //Debug.Log(SceneManager.GetActiveScene().name);
        //playerPosition.transform.position = new Vector2(10, 10);
        CheckScenario();

        player.position = playerPosition.transform.position;

        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        player.GetComponent<PlayerController>().enabled = true;
    }

    void CheckScenario()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", null);

        if (SceneManager.GetActiveScene().name == "Scene0-Town" && lastScene == "Scene1-Forest")
            playerPosition.transform.position = Scene1Door();
        else if (SceneManager.GetActiveScene().name == "Scene1-Forest" && lastScene == "Scene0-Town")
            playerPosition.transform.position = Scene2Entrace();
    }

    Vector2 Scene1Door()
    {
        return new Vector2(80.7f, -2.7f);
    }

    Vector2 Scene2Entrace()
    {
        return new Vector2(-4.5f, -1.5f);
    }
}
