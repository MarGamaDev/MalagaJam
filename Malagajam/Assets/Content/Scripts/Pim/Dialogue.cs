using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue : MonoBehaviour
{
    public enum DialogueType
    {
        Base,
        Quest,
        Post
    }
    public DialogueType dialogueType = DialogueType.Base;

    public string Name;

    [HideInInspector] public bool textActive;

    [Space]
    public TMP_Text nameText;
    public TMP_Text text;
    private int currentIndex = 0;

    [Space]
    [SerializeField] private DialogueObject _baseDialogue;
    [SerializeField] private DialogueObject _questDialogue;
    [SerializeField] private DialogueObject _postDialogue;
    private DialogueObject _currentDialogue;

    public GameObject dialoguecontroller;

    public PlayerController playerMovement;

    public UnityEvent EndOfDialogueEvent;

    [SerializeField] private AudioSource _talkAudio;

    private void Start()
    {
        _currentDialogue = _baseDialogue;
    }

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
        if (_currentDialogue.Sentences[currentIndex] == null || _currentDialogue.Sentences[currentIndex + 1] == "" || _currentDialogue.Sentences[currentIndex] == "")
        {
            RemoveText();

        }
        else
        {
            currentIndex++;
            StopAllCoroutines();
            StartCoroutine(TypeSentance(_currentDialogue.Sentences[currentIndex]));

        }
    }

    void InitiateText()
    {
        StopAllCoroutines();
        playerMovement.movementEnabled = false;
        textActive = true;
        dialoguecontroller.active = true;

        nameText.text = Name;
        StartCoroutine(TypeSentance(_currentDialogue.Sentences[currentIndex]));
    }

    void RemoveText()
    {
        playerMovement.movementEnabled = true;
        textActive = false;
        EndOfDialogueEvent?.Invoke();
        dialoguecontroller.active = false;
    }

    IEnumerator TypeSentance(string sentance)
    {
        text.text = "";
        foreach(char letter in sentance.ToCharArray())
        {
            if (!_talkAudio.isPlaying)
            {
                _talkAudio.Play();
            }
            text.text += letter;
            yield return null;
        }
        _talkAudio.Stop();
    }

    public void SwitchDialogue(DialogueType dialogueType)
    {
        this.dialogueType = dialogueType;
        switch (this.dialogueType)
        {
            case DialogueType.Base:
                _currentDialogue = _baseDialogue;
                break;
            case DialogueType.Quest:
                _currentDialogue = _questDialogue;
                break;
            case DialogueType.Post:
                _currentDialogue = _postDialogue;
                break;
            default:
                break;
        }
    }
}
