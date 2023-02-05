using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public bool _doBehaviour = true;
    [SerializeField] private LevelCameraBox _currentCamBox;
    [SerializeField] private Transform _followTarget;

    [SerializeField] private float _distanceFromTarget;
    private Quaternion _startRotation;

    private void Awake()
    {
        _startRotation = transform.rotation;
    }

    private void Update()
    {
        if (_doBehaviour && _currentCamBox)
        {
            transform.rotation = _startRotation;
            Vector3 wantedPosition = GetWantedPosition();
            transform.position = ClampPositionInBox(wantedPosition);
        }
    }

    #region stay in box
    private Vector3 GetWantedPosition()
    {
        Vector3 wantedPosition = _followTarget.position - transform.forward * _distanceFromTarget;
        return wantedPosition;
    }

    private Vector3 ClampPositionInBox(Vector3 wantedPosition)
    {
        float clampedX = Mathf.Clamp(wantedPosition.x, _currentCamBox.MinCameraBounds.x, _currentCamBox.MaxCameraBounds.x);
        float clampedY = Mathf.Clamp(wantedPosition.y, _currentCamBox.MinCameraBounds.y, _currentCamBox.MaxCameraBounds.y);
        float clampedZ = Mathf.Clamp(wantedPosition.z, _currentCamBox.MinCameraBounds.z, _currentCamBox.MaxCameraBounds.z);
        return new Vector3(clampedX, clampedY, clampedZ);
    }
    #endregion

    #region transition between boxes
    public void MoveToNewScreen(LevelCameraBox newCamBox)
    {
        _currentCamBox= newCamBox;
    }
    #endregion
}
