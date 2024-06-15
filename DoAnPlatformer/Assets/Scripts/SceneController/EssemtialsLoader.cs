using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EssemtialsLoader : MonoBehaviour
{
    [SerializeField] GameObject UiBoard, Player;

    //only using to spawn out the character for the first time
    private void Awake()
    {
        //load ui system manager (health, inventory, option..)
        if (UISystemManager.instance == null)
        {
            Instantiate(UiBoard);
        }

        //load player
        if (PlayerManager.instance == null)
        {
            Instantiate(Player);
        }
    }
}
