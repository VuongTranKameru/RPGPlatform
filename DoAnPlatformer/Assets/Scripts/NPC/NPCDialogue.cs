using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    internal static NPCDialogue instance;
    NPC_UI_DialogNarrative narrative;
    Animator anim;

    [Header("Dialog")]
    public float wordSpeed;
    public bool playerIsClose;
    int endLine = 0;
    bool doneText = false;

    private void Awake()
    {
        instance = this;

        narrative = FindAnyObjectByType<NPC_UI_DialogNarrative>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        narrative.dialogueText.text = "";
    }

    void Update()
    {
        //Debug.Log(endLine);

        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            anim.SetBool("Talking", true);
            if (!narrative.dialoguePanel.activeInHierarchy)
            {
                // bat khung textbox len
                narrative.dialoguePanel.SetActive(true);
                narrative.continueBtn.SetActive(true);
                // chay line dialog dau tien
                StartCoroutine(Typing(endLine));
                anim.SetBool("Talking", false);
            }
            else if (narrative.dialoguePanel.activeInHierarchy && Input.GetKeyDown(KeyCode.E) && doneText)
            {
                NextLine(); //chay dong 2nd tro len
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && narrative.dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            RemoveText();
        }
    }

    IEnumerator Typing(int countLine)
    {
        //word by word in a dialogue
        foreach (char letter in narrative.dialogue[countLine].ToCharArray())
        {
            narrative.dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

        doneText = true;
    }

    void NextLine()
    {
        if (endLine < narrative.dialogue.Length - 1 && doneText)
        {
            endLine++;
            narrative.dialogueText.text = "";
            StartCoroutine(Typing(endLine));
            if(endLine == narrative.dialogue.Length - 1)
            {
                narrative.continueBtn.SetActive(false);
                narrative.exitBtn.SetActive(true);
            }
            doneText = false;
        }
        else
        {
            //het line nen xoa text
            RemoveText();
        }
    }

    public void RemoveText()
    {
        narrative.dialogueText.text = "";
        endLine = 0; //reset
        narrative.exitBtn.SetActive(false);
        narrative.dialoguePanel.SetActive(false);
    }
}

