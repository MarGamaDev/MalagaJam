using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private LevelCameraBox _currentLevelBox;
    [SerializeField] private Transform _followTarget;

    [SerializeField] private float _distanceFromTarget;

    private void Update()
    {
        if (!_currentLevelBox)
        {
            Debug.Log("no camera box recognized for camera");
            return;
        }

        Vector3 wantedPosition = GetWantedPosition();
        transform.position = ClampPositionInBox(wantedPosition);
    }

    private Vector3 GetWantedPosition()
    {
        Vector3 wantedPosition = _followTarget.position - transform.forward * _distanceFromTarget;
        return wantedPosition;
    }

    private Vector3 ClampPositionInBox(Vector3 wantedPosition)
    {
        float clampedX = Mathf.Clamp(wantedPosition.x, _currentLevelBox.MinCameraBounds.x, _currentLevelBox.MaxCameraBounds.x);
        float clampedY = Mathf.Clamp(wantedPosition.y, _currentLevelBox.MinCameraBounds.y, _currentLevelBox.MaxCameraBounds.y);
        float clampedZ = Mathf.Clamp(wantedPosition.z, _currentLevelBox.MinCameraBounds.z, _currentLevelBox.MaxCameraBounds.z);
        return new Vector3(clampedX, clampedY, clampedZ);
    }
}
