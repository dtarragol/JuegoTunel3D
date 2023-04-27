using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeleportDestination : MonoBehaviour
{
    public Vector3 teleportPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportPosition;
        }
    }
}