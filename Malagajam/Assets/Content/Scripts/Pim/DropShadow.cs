using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{

    [SerializeField] Transform player;

    public LayerMask groundLayer;

    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer= GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {    
        if (Physics.Raycast(player.position, -transform.up, out RaycastHit hit, 10, groundLayer))
        {
            meshRenderer.enabled = true;
            transform.position = hit.point;
            return;
        }
        meshRenderer.enabled = false;
    }
}
