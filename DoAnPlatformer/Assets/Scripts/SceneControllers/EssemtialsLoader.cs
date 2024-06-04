using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssemtialsLoader : MonoBehaviour
{
    [SerializeField] GameObject playerUI, pauseBoard;

    private void Awake()
    {
        if (UISystemManager.instance == null)
        {
            Instantiate(playerUI); 
            Instantiate(pauseBoard);
        }
    }
}
