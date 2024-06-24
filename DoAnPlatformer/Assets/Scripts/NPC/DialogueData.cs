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
public class DialogueData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] internal GameObject nameNPC;
    [SerializeField] internal string[] dialogue;
    [SerializeField] internal DialogueType type;
    /*[SerializeField] internal GameObject dialoguePanel;
    [SerializeField] internal TMP_Text dialogueText;*/
}