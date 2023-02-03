using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance = _instance;

    [SerializeField] private CameraMovement _camMovement;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

        _camMovement = Camera.main.GetComponent<CameraMovement>();
    }

    public void TransitionToNewScreen(LevelCameraBox newCamBox, Vector3 targetPosition)
    {
        
    }

    private IEnumerator CamTransition(LevelCameraBox newCamBox, Vector3 targetPosition)
    {
        //fade to black
        //move player to new position
        //change camera box
        //
    }
}
