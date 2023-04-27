using UnityEngine;
using System.Collections;

public class MovingBlock : MonoBehaviour
{
    public GameObject blockToMove;
    public float moveSpeed = 1f;
    private bool playerInTrigger = false;
    private Vector3 startPosition;
    public float blockPositionX = 0f;

    // Variables para el teletransporte
    private bool hasReachedEndPosition = false;
    public float teleportPositionX = 0f;
    public float teleportDelay = 1f;
    private int blocksMoved = 0;
    public int blocksToTeleport = 40;

    private void Start()
    {
        startPosition = blockToMove.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void Update()
    {
        if (playerInTrigger)
        {
            Vector3 newPosition = blockToMove.transform.position;
            newPosition.x = blockPositionX;
            blockToMove.transform.position = Vector3.MoveTowards(blockToMove.transform.position, newPosition, moveSpeed * Time.deltaTime);

            // Verificar si el objeto ha movido suficientes bloques para teletransportarlo
            if (blocksMoved >= blocksToTeleport && !hasReachedEndPosition)
            {
                hasReachedEndPosition = true;
                StartCoroutine(TeleportBlock());
            }

            // Incrementar el número de bloques que ha movido el objeto
            if (!hasReachedEndPosition)
            {
                blocksMoved++;
            }
        }
        else if (hasReachedEndPosition)
        {
            blockToMove.transform.position = Vector3.MoveTowards(blockToMove.transform.position, startPosition, moveSpeed * Time.deltaTime);
            if (blockToMove.transform.position == startPosition)
            {
                hasReachedEndPosition = false;
                blocksMoved = 0;
            }
        }
    }

    private IEnumerator TeleportBlock()
    {
        yield return new WaitForSeconds(teleportDelay);
        Vector3 teleportPosition = new Vector3(teleportPositionX, blockToMove.transform.position.y, blockToMove.transform.position.z);
        blockToMove.transform.position = teleportPosition;
    }
}