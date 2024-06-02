using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystemManager : MonoBehaviour
{
    internal static UISystemManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
