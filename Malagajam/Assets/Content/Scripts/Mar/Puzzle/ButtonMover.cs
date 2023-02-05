using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1, _timeBeforeStop = 5;

    public void MoveButtonsDown()
    {
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        float timer = 0;
        while (timer < _timeBeforeStop)
        {
            transform.position += Vector3.down * (_moveSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
