using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform playerPosition, player;

    private void Awake()
    {
        player.GetComponent<PlayerController>().enabled = false;
    }

    void FixedUpdate()
    {
        CheckScenario();

        //if not return to where player from, check make active and lead to near the door
        if (!player.GetComponent<PlayerController>().enabled)
        {
            player.position = playerPosition.transform.position;

            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();

            player.GetComponent<PlayerController>().enabled = true;
        }

        //Debug.Log(PlayerPrefs.GetString("LastScene"));
    }

    void CheckScenario()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");

        if (SceneManager.GetActiveScene().name == "Scene0-Town" && lastScene == "Scene1-Forest")
        {   //from town to forest
            playerPosition.transform.position = Scene1Door();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("town");
        }
        else if ((SceneManager.GetActiveScene().name == "Scene1-Forest" && lastScene == "Scene0-Town") ||
            (SceneManager.GetActiveScene().name == "Scene1-Forest" && lastScene == "Scene-IntroTown"))
        {   //from forest to town
            playerPosition.transform.position = Scene2Entrace();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("forest");
        }
        else if (SceneManager.GetActiveScene().name == "Scene2-MineCave" && lastScene == "Scene1-Forest")
        {   //from forest to cave
            playerPosition.transform.position = Scene3Entrace();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("cave");
        }
        else if (SceneManager.GetActiveScene().name == "Scene1-Forest" && lastScene == "Scene2-MineCave")
        {   //from cave to forest
            playerPosition.transform.position = Scene2Exit();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("forest");
        }
        else if (SceneManager.GetActiveScene().name == "Scene-Boss" && lastScene == "Scene2-MineCave")
        {   //from cave to forest
            playerPosition.transform.position = Scene3Exit();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("forest");
        }
        else if (SceneManager.GetActiveScene().name == "Scene2-MineCave" && lastScene == "Scene-Boss")
        {   //from cave to forest
            playerPosition.transform.position = Scene3Entrace();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("forest");
        }
    }

    Vector2 Scene1Door()
    {
        return new Vector2(80f, -2.5f);
    }

    Vector2 Scene2Entrace()
    {
        return new Vector2(81f, -4.8f);
    }

    Vector2 Scene2Exit()
    {
        return new Vector2(213f, -4.6f);
    }

    Vector2 Scene3Entrace()
    {
        return new Vector2(2f, -2f);
    }

    Vector2 Scene3Exit()
    {
        return new Vector2(-4.5f, -1.9f);
    }
}
