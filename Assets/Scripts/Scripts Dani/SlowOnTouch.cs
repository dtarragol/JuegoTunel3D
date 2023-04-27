
using UnityEngine;

public class SlowOnTouch : MonoBehaviour
{
    [Header("Movement")]
    public GameObject playerObject;
    private float originalSpeed;
    private VRMovement movementComponent;
    public float slowSpeed = 0.5f;

    private void Start()
    {
        movementComponent = playerObject.GetComponent<VRMovement>(); // Obtener el componente FirstPersonMovement del objeto del jugador
        originalSpeed = movementComponent.velocidad; // Guardar la velocidad original de movimiento
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movementComponent.velocidad = slowSpeed; // Reducir la velocidad al valor deseado
            Debug.Log("Velocidad de movimiento reducida a: " + movementComponent.velocidad); // Verificar que la velocidad se establece correctamente
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            movementComponent.velocidad = originalSpeed; // Restaurar la velocidad original
            Debug.Log("Velocidad de movimiento restaurada a: " + movementComponent.velocidad); // Verificar que la velocidad se restaura correctamente
        }
    }
}
