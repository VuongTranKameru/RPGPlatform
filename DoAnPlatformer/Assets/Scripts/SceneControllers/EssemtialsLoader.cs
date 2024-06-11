using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EssemtialsLoader : MonoBehaviour
{
    [SerializeField] GameObject UiBoard;

    private void Awake()
    {
        if (UISystemManager.instance == null)
        {
            Instantiate(UiBoard);
        }
    }
}
