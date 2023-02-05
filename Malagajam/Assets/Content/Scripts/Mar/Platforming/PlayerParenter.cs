using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParenter : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.transform.parent == transform)
        {
            other.transform.parent = null;
        }
    }
}
