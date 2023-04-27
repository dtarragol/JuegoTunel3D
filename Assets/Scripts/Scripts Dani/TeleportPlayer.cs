using UnityEngine;

public class TeleportPlayer : MonoBehaviour
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
