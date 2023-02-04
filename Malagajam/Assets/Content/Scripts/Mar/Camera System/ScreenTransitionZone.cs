using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTransitionZone : MonoBehaviour
{
    [SerializeField] private ScreenTransitionZone _partnerZone;
    public Transform _exitPoint;
    public LevelCameraBox _camBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraManager.Instance.TransitionToNewScreen(_partnerZone._camBox, _partnerZone._exitPoint.position);
        }
    }
}
