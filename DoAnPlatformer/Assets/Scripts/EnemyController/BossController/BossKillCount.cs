using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillCount : MonoBehaviour
{
    internal static BossKillCount instance;

    [SerializeField] GameObject boss, openEnding;
    internal bool checkBossClear = false;

    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (boss != null && openEnding != null)
            if (!boss.activeInHierarchy)
            {
                openEnding.SetActive(true);
                checkBossClear = true;
            }
    }
}
