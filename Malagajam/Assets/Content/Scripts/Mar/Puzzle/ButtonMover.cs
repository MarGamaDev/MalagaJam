using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1, _timeBeforeStop = 5;

    public void MoveButtonsDown()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.layer = 0;
        }
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
