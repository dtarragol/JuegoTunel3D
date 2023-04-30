using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Velocidad de rotaci�n en grados por segundo

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime); // Rotaci�n sobre el eje Z
    }
}