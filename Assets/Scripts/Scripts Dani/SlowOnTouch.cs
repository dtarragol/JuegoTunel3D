
using System.Collections;
using UnityEngine;

/*public class SlowOnTouch : MonoBehaviour
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
}*/

public class SlowOnTouch : MonoBehaviour
{
    [Header("Movement")]
    public GameObject playerObject;
    private float originalSpeed;
    private VRMovement movementComponent;
    public float slowSpeed = 0.5f;
    public float slowDuration = 2.0f;
    private bool isSlowed = false;

    private void Start()
    {
        movementComponent = playerObject.GetComponent<VRMovement>(); // Obtener el componente FirstPersonMovement del objeto del jugador
        originalSpeed = movementComponent.velocidad; // Guardar la velocidad original de movimiento
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isSlowed)
            {
                isSlowed = true;
                movementComponent.velocidad = slowSpeed; // Reducir la velocidad al valor deseado
                Debug.Log("Velocidad de movimiento reducida a: " + movementComponent.velocidad); // Verificar que la velocidad se establece correctamente
                StartCoroutine(SlowDuration()); // Iniciar la corrutina para restaurar la velocidad del jugador después de un tiempo determinado
            }
        }
    }

    IEnumerator SlowDuration()
    {
        // Esperar un tiempo antes de restaurar la velocidad del jugador
        yield return new WaitForSeconds(slowDuration);

        // Restaurar la velocidad original del jugador
        movementComponent.velocidad = originalSpeed;
        isSlowed = false;
        Debug.Log("Velocidad de movimiento restaurada a: " + movementComponent.velocidad); // Verificar que la velocidad se restaura correctamente
    }
}
