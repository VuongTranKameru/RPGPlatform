using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogue : MonoBehaviour
{
    [SerializeField] GameObject Dialogue;

    void Start()
    {
        Dialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitFromTalk()
    {
        Dialogue.SetActive(false);
        Time.timeScale = 1f;
    }
}
