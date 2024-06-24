using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillCount : MonoBehaviour
{
    internal static BossKillCount instance;

    [SerializeField] GameObject boss;
    internal bool checkBossClear = false;

    void Start()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (boss != null)
            if (!boss.activeInHierarchy)
            {
                Debug.Log("ye");
                checkBossClear = true;
            }
    }
}
