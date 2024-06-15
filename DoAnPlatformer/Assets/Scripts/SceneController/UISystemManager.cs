using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystemManager : MonoBehaviour
{
    internal static UISystemManager instance;

    void Start()
    {
        //check if ui system manager exist
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
