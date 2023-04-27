using UnityEngine;

public class MoveAndRegenerate : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveSpeed = 1f;
    public float blockPositionX = 0f;
    public float regenerationDelay = 1f;
    public Vector3 regenerationPosition = Vector3.zero;

    private Vector3 startPosition;
    private bool objectIsMoving = false;
    private bool objectIsRegenerating = false;

    private void Start()
    {
        startPosition = objectToMove.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!objectIsMoving && !objectIsRegenerating)
            {
                objectIsMoving = true;
            }
        }
    }

    private void Update()
    {
        if (objectIsMoving)
        {
            Vector3 newPosition = objectToMove.transform.position;
            newPosition.x = blockPositionX;
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, newPosition, moveSpeed * Time.deltaTime);

            if (objectToMove.transform.position == newPosition)
            {
                objectIsMoving = false;
                objectIsRegenerating = true;
                Invoke("RegenerateObject", regenerationDelay);
            }
        }
    }

    private void RegenerateObject()
    {
        objectToMove.transform.position = regenerationPosition;
        objectIsRegenerating = false;
    }
}