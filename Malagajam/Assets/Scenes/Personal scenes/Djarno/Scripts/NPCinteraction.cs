using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCinteraction : MonoBehaviour, IInteractable
{
    public GameObject MainCamera;
    public GameObject CamNPC0;
    private Dialogue _dialogue;
    private LookAtNpc _LookAtNPC;

    private void Start()
    {
        MainCamera.SetActive(true);
        CamNPC0.SetActive(false);
        _dialogue = GetComponent<Dialogue>();
        _LookAtNPC = GetComponent<LookAtNpc>();
    }

    public void Interact()
    {
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

    public void ResetCams()
    {
        MainCamera.SetActive(true);
        CamNPC0.SetActive(false);
        Debug.Log("Turned MainCam ON");
        Debug.Log("Turned CamNPC0 OFF");
    }
}
