using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionGrabber : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckForPlayer();
    }

    private void CheckForPlayer()
    {
        if (Physics.OverlapSphere(transform.position, 2.5f, _playerMask).Length > 0)
        {
            _spriteRenderer.enabled = true;
            return;
        }
        _spriteRenderer.enabled = false;
    }
}
