using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public bool panelIsActive;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    void Update()
    { 

        if(Input.GetKeyDown(KeyCode.C) && playerIsClose && !panelIsActive)
        {
            if(dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                panelIsActive = true;
                StartCoroutine(Typing());
            }
        } else if (Input.GetKeyDown(KeyCode.C) && playerIsClose && panelIsActive && dialogueText.text == dialogue[index])
        {
            NextLine();
        }

        if (dialogueText.text == dialogue[index]) {
            contButton.SetActive(true);
        }
        
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing() 
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zeroText();
            playerIsClose = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            zeroText();
            playerIsClose = false;
            panelIsActive = false;
        }
    }
}
