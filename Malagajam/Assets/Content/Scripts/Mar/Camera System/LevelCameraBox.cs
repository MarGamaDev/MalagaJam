using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCameraBox : MonoBehaviour
{
    [SerializeField] private Transform _minHandle, _maxHandle;

    public Vector3 MinCameraBounds => _minHandle.position;
    public Vector3 MaxCameraBounds => _maxHandle.position;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Vector3 boxSize = new Vector3(_maxHandle.position.x - _minHandle.position.x, _maxHandle.position.y - _minHandle.position.y, _maxHandle.position.z - _minHandle.position.z);
        Vector3 boxCenter = new Vector3(_minHandle.position.x + ((boxSize.x) / 2), _minHandle.position.y + ((boxSize.y) / 2), _minHandle.position.z + ((boxSize.z) / 2));
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
