using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCinteraction : MonoBehaviour, IInteractable
{
    private GameObject MainCamera;
    public GameObject CamNPC0;
    private Dialogue _dialogue;
    private LookAtNpc _LookAtNPC;
    [SerializeField] private List<string> _dialogueChangeItemConditions;
    [SerializeField] private GameObject _questReward;

    private void Start()
    {
        MainCamera = Camera.main.gameObject;
        MainCamera.SetActive(true);
        CamNPC0.SetActive(false);
        _dialogue = GetComponent<Dialogue>();
        _LookAtNPC = GetComponent<LookAtNpc>();
    }

    public void Interact()
    {
        CheckBaseToQuestCondition();

        if (!_dialogue.textActive)
        {
            CamNPC0.transform.LookAt(_LookAtNPC.FindClosestTarget());
            MainCamera.SetActive(false);
            CamNPC0.SetActive(true);
            Debug.Log("Turned MainCam OFF");
            Debug.Log("Turned CamNPC0 ON");
        }

        _dialogue.MoveThroughDialogue();
    }

    private void CheckBaseToQuestCondition()
    {
        bool questDone = true;
        foreach (string item in _dialogueChangeItemConditions)
        {
            if (!GameManager.Instance.IsItemInList(item))
            {
                questDone = false;
            }
        }

        if (questDone && _dialogue.dialogueType == Dialogue.DialogueType.Base)
        {
            _dialogue.SwitchDialogue(Dialogue.DialogueType.Quest);
        }
    }

    public void CompleteQuest()
    {
        if (_dialogue.dialogueType != Dialogue.DialogueType.Quest)
        {
            return;
        }

        //throw out item
        _questReward.SetActive(true);

        //change to post text
        _dialogue.SwitchDialogue(Dialogue.DialogueType.Post);
    }

    public void ResetCams()
    {
        MainCamera.SetActive(true);
        CamNPC0.SetActive(false);
        Debug.Log("Turned MainCam ON");
        Debug.Log("Turned CamNPC0 OFF");
    }
}
