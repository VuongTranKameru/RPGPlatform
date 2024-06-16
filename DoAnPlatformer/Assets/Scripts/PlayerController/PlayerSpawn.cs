using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] Transform playerPosition, player;

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
    }

    void CheckScenario()
    {
        string lastScene = PlayerPrefs.GetString("LastScene");

        if (SceneManager.GetActiveScene().name == "Scene0-Town" && lastScene == "Scene1-Forest")
        {
            playerPosition.transform.position = Scene1Door();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("town");
        }
        else if (SceneManager.GetActiveScene().name == "Scene1-Forest" && lastScene == "Scene0-Town")
        {
            playerPosition.transform.position = Scene2Entrace();
            player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("forest");
        }
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
