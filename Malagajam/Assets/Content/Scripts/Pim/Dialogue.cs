using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public string name;

    [HideInInspector] public bool textActive;

    public TMP_Text nameText;
    public TMP_Text text;
    private int currentIndex = 0;

    [TextArea(0, 10)]
    public string[] sentances;

    public GameObject dialoguecontroller;

    public PlayerController playerMovement;

    public UnityEvent EndOfDialogueEvent;

    public void MoveThroughDialogue()
    {
        if (!textActive)
        {
            InitiateText();
        }
        else
        {
            ChangeSentence();
        }
    }

    void ChangeSentence()
    {
        if (sentances[currentIndex] == null || sentances[currentIndex + 1] == "")
        {
            RemoveText();
            playerMovement.movementEnabled = true;
        }
        else
        {
            currentIndex++;
            StopAllCoroutines();
            StartCoroutine(TypeSentance(sentances[currentIndex]));

        }

    }

    void InitiateText()
    {
        playerMovement.movementEnabled = false;
        textActive = true;
        dialoguecontroller.transform.position = new Vector3(dialoguecontroller.transform.position.x, dialoguecontroller.transform.position.y + 500);

        nameText.text = name;
        StartCoroutine(TypeSentance(sentances[currentIndex]));
    }

    void RemoveText()
    {
        textActive = false;
        EndOfDialogueEvent?.Invoke();
        dialoguecontroller.transform.position = new Vector3(dialoguecontroller.transform.position.x, dialoguecontroller.transform.position.y - 500, dialoguecontroller.transform.position.z);
        currentIndex = 0;
    }

    IEnumerator TypeSentance(string sentance)
    {
        text.text = "";
        foreach(char letter in sentance.ToCharArray())
        {
            text.text += letter;
            yield return null;
            yield return null;
        }
    } 
}
