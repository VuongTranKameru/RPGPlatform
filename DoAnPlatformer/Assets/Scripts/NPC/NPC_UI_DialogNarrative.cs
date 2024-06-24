using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_UI_DialogNarrative : MonoBehaviour
{
    [SerializeField] internal GameObject dialoguePanel;
    [SerializeField] internal TMP_Text dialogueText;
    [SerializeField] internal string[] dialogue;
    [SerializeField] internal GameObject continueBtn, exitBtn;

    private void Start()
    {
        if (dialoguePanel.activeInHierarchy)
            dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        InTalk();
    }

    void InTalk()
    {
        if (dialoguePanel.activeInHierarchy)
            PlayerController.instance.standStillWhileTalk = true;
        else if (!dialoguePanel.activeInHierarchy)
            PlayerController.instance.standStillWhileTalk = false; 
    }

    public void ExitFromTalk()
    {
        NPCDialogue.instance.RemoveText();
    }
}
