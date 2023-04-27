using UnityEngine;


public class EnemyTeleport : MonoBehaviour
{
    public GameObject player;
    public Vector3 teleportPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teleporting player to position: " + teleportPosition);
            player.transform.position = teleportPosition;
        }
    }
}