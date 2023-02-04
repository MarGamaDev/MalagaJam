using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string name;

    bool textActive;
    bool inTriggerRange;

    public TMP_Text nameText;
    public TMP_Text text;
    private int currentIndex = 0;

    [TextArea(0, 10)]
    public string[] sentances;

    public GameObject dialoguecontroller;

    public PlayerMovement playerMovement;

    private void Update()
    {
        if(textActive)
        {
            playerMovement.movementEnabled = false;
        }
        else if (!textActive)
        {
            playerMovement.movementEnabled = true;
        }

        if(inTriggerRange)
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!textActive)
            {
                InitiateText();
            }
            else if (textActive)
            {
                ChangeSentance();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTriggerRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inTriggerRange = false;
    }

    void ChangeSentance()
    {
        if (sentances[currentIndex] == null || sentances[currentIndex + 1] == "")
        {
            RemoveText();
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
        textActive = true;
        dialoguecontroller.transform.position = new Vector3(dialoguecontroller.transform.position.x, dialoguecontroller.transform.position.y + 500);

        nameText.text = name;
        StartCoroutine(TypeSentance(sentances[currentIndex]));
    }

    void RemoveText()
    {
        textActive = false;
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
