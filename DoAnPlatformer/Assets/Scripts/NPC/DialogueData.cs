using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum DialogueType
{
    TalkOnly,
    Shopping
}

[CreateAssetMenu(fileName = "Dialog", menuName = "NewDialog")]
public class DiallgueData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] internal GameObject dialoguePanel;
    [SerializeField] internal TMP_Text dialogueText;
    [SerializeField] internal string[] dialogue;
    [SerializeField] internal DialogueType type;

    [Header("Optional")]
    [SerializeField] internal GameObject continueBtn, exitBtn;
}