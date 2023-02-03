using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCameraBox : MonoBehaviour
{
    [SerializeField] private Transform _minHandle, _maxHandle;
    private Vector2 _minCameraBounds, _maxCameraBounds;
    public Vector2 MinCameraBounds => _minCameraBounds;
    public Vector2 MaxCameraBounds => _maxCameraBounds;

    private void OnDrawGizmosSelected()
    {

    }
}
