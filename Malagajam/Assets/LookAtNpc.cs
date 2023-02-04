using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtNpc : MonoBehaviour
{
    public Transform FindClosestTarget()
    {
        GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
        Transform Closest = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject NPC in NPCs)
        {
            float dist = Vector3.Distance(NPC.transform.position , currentPos);
            if (dist < minDist)
            {
                Closest = NPC.transform;
                minDist = dist;
            }
        }
        return Closest.transform;  
    }
}
