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
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, 10, groundLayer))
        {
            meshRenderer.enabled = true;
        }
        else meshRenderer.enabled = false;
    }
}
