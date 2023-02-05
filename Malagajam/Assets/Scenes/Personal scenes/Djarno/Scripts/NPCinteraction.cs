using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCinteraction : MonoBehaviour, IInteractable
{
    private CameraMovement _camMovement;
    private Dialogue _dialogue;
    private LookAtNpc _LookAtNPC;
    [SerializeField] private List<string> _dialogueChangeItemConditions;
    [SerializeField] private GameObject _questReward;

    private void Start()
    {
        _camMovement = Camera.main.GetComponent<CameraMovement>();
        _dialogue = GetComponent<Dialogue>();
        _LookAtNPC = GetComponent<LookAtNpc>();
    }

    public void Interact()
    {
        CheckBaseToQuestCondition();

        if (!_dialogue.textActive)
        {
            Transform camTarget = _LookAtNPC.FindClosestTarget();
            Camera.main.transform.LookAt(camTarget);
            Camera.main.transform.position = camTarget.position - Camera.main.transform.forward * 2;
            _camMovement._doBehaviour = false;
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
        _camMovement._doBehaviour = true;
    }
}
