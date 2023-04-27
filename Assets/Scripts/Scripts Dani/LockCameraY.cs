using UnityEngine;

public class LockCameraY : MonoBehaviour
{
    public float cameraHeight = 1.0f;

    private void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = cameraHeight;
        transform.position = newPosition;
    }
}