using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBob : MonoBehaviour
{
    public bool IsFloating = true;
    [SerializeField] private float _bobSpeed = 1, _bobIntensity = 1, _bobOffset;
    [SerializeField] private Vector3 _bobDirection = Vector3.up;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (!IsFloating) { return; }
        transform.position = _startPosition + _bobDirection.normalized * ( _bobIntensity * Mathf.Sin(_bobSpeed * Time.time + _bobOffset));
    }
}
