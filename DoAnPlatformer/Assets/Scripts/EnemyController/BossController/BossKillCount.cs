using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillCount : MonoBehaviour
{
    internal static BossKillCount instance;

    [SerializeField] GameObject boss, setEnding;
    internal bool checkBossClear = false;

    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (boss != null && setEnding != null)
            if (!boss.activeInHierarchy)
            {
                setEnding.SetActive(true);
                checkBossClear = true;
            }
    }
}
