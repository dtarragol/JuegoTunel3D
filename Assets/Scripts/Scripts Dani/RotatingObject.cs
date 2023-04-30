using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Velocidad de rotación en grados por segundo

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // Rotación sobre el eje Z
    }
}