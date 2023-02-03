using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCinteraction : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject CamNPC0;
    public GameObject CamNPC1;
    public GameObject CamNPC2;

    private void Start()
    {
        MainCamera.SetActive(true);
        CamNPC0.SetActive(false);
        CamNPC1.SetActive(false);
        CamNPC2.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Detected");

            if (Input.GetKeyDown(KeyCode.E))
            {
                MainCamera.SetActive(false);
                CamNPC0.SetActive(true);
                CamNPC1.SetActive(false);
                CamNPC2.SetActive(false);

                Debug.Log("Turned MainCam OFF");
                Debug.Log("Turned CamNPC0 ON");
            }
        }
    }
}
