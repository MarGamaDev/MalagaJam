using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private enum BillboardType
    {
        LookAtCamera,
        CameraDirection
    }

    [SerializeField] private BillboardType _billboardType;

    private void Update()
    {
        switch (_billboardType)
        {
            case BillboardType.LookAtCamera:
                transform.LookAt(-(Camera.main.transform.position - transform.position));
                break;
            case BillboardType.CameraDirection:
                transform.LookAt(transform.position + Camera.main.transform.forward);
                break;
            default:
                break;
        }
    }
}
