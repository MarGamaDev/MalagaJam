using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSquare : MonoBehaviour
{
    public enum Orientation
    {
        Up,
        Left,
        Down,
        Right
    }

    public Orientation CurrentOrientation = Orientation.Up;
    public Orientation _targetOrientation = Orientation.Up;

    [SerializeField] private float _timeToSpin = 1f;

    private Vector3 _startPosition;
    [SerializeField] private float _offsetWhenSpinning = 1f;
    [SerializeField] private float _timeToOffsetInSeconds = 0.5f;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        SpinClockwise();
    }

    private void SpinClockwise()
    {
        CurrentOrientation = (Orientation)Mathf.FloorToInt(transform.rotation.eulerAngles.z % 360 / 90);
        float degrees = ((int)_targetOrientation) * 90;

        if (CurrentOrientation == _targetOrientation)
        {
            transform.position = Vector3.MoveTowards(transform.position,_startPosition, _offsetWhenSpinning * Time.deltaTime / _timeToOffsetInSeconds);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, degrees));
        } 
        else 
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition + (transform.forward * -_offsetWhenSpinning), _offsetWhenSpinning * Time.deltaTime / _timeToOffsetInSeconds);
            transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime / _timeToSpin));
        }  
    }

    public void SpinOnce()
    {
        _targetOrientation = (Orientation)(((int)_targetOrientation + 1) % 4);
    }
}
