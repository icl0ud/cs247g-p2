using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public TMPro.TMP_Text continueText;
    public string[] dialogue;
    private int index;
    public bool panelIsActive;
    public float wordSpeed;
    public Animator m_Animator;


    void Update()
    { 

        if(!panelIsActive)
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
        } 
        else if (Input.GetKeyDown(KeyCode.C) && panelIsActive && dialogueText.text == dialogue[index])
        {
            m_Animator.SetTrigger("NextPanel");
            NextLine();
        }

        if (dialogueText.text == dialogue[index]) {
            continueText.enabled = true;
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        SceneManager.LoadScene("Tutorial");
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
        continueText.enabled = false;

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
}
