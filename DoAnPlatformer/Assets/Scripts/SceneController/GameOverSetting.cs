using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSetting : MonoBehaviour
{
    [SerializeField] GameObject UiBoard;

    void Start()
    {
        if (PlayerManager.instance != null)
            Destroy(PlayerManager.instance.gameObject);

        if (UISystemManager.instance == null)
            Instantiate(UiBoard);
    }
}
