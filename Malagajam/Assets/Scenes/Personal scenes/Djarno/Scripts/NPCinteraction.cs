using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCinteraction : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject CamNPC0;

    public LayerMask playerMask;

    private void Start()
    {
        MainCamera.SetActive(true);
        CamNPC0.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttemptInteract();
        }
    }

    void AttemptInteract()
    {
        if (Physics.OverlapSphere(transform.position, 2, playerMask).Length > 0)
        {
            MainCamera.SetActive(false);
            CamNPC0.SetActive(true);

            Debug.Log("Turned MainCam OFF");
            Debug.Log("Turned CamNPC0 ON");
        }
    }
}
