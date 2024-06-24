using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    internal static Teleport instance;

    [SerializeField] Transform playerPosition, player;

    void Awake()
    {
        instance = this;
    }

    public void TeleportPotionActive()
    {
        SceneManager.LoadScene("Scene0-Town");

        playerPosition.transform.position = SceneTown();
        player.GetComponent<PlayerController>().enabled = false;
        Debug.Log("return");

        if (!player.GetComponent<PlayerController>().enabled)
        {
            player.position = playerPosition.transform.position;

            PlayerPrefs.SetString("LastScene", "Scene1-Forest");
            PlayerPrefs.Save();

            player.GetComponent<PlayerController>().enabled = true;
        }
    }

    Vector2 SceneTown()
    {
        return new Vector2(80f, -2.5f);
    }
}
