using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{

    [SerializeField] Transform player;

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
}
