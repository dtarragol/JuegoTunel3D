/*using UnityEngine;


public class EnemyTeleport : MonoBehaviour
{
    public GameObject Player;
    public Vector3 teleportPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Teleporting player to position: " + teleportPosition);
            Player.transform.position = teleportPosition;
        }
    }
}*/

using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3 teleportPosition;

    private CharacterController characterController;
    private bool isDisabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isDisabled)
            {
                DisableCharacterController();
                Debug.Log("Teleporting player to position: " + teleportPosition);
                playerObject.transform.position = teleportPosition;
                Invoke("EnableCharacterController", 1.0f);
            }
        }
    }

    private void DisableCharacterController()
    {
        characterController = playerObject.GetComponent<CharacterController>();
        if (characterController)
        {
            characterController.enabled = false;
            isDisabled = true;
        }
    }

    private void EnableCharacterController()
    {
        if (characterController)
        {
            characterController.enabled = true;
            isDisabled = false;
        }
    }
}