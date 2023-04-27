using UnityEngine;

/*public class VRMovement : MonoBehaviour
{
    public float velocidad = 1.0f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Obtener la dirección hacia donde mira la cámara
        Vector3 direction = Camera.main.transform.forward;
        // Ignorar la dirección en el eje Y para evitar que el jugador vuele
        direction.y = 0f;
        // Normalizar la dirección para que tenga una magnitud de 1
        direction.Normalize();

        // Mover el personaje en la dirección calculada
        characterController.Move(direction * velocidad * Time.deltaTime);
    }
}*/
public class VRMovement : MonoBehaviour
{
    public float velocidad = 1.0f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // Si no hay entrada de movimiento, no hacer nada
        if (Mathf.Approximately(inputX, 0) && Mathf.Approximately(inputZ, 0))
        {
            return;
        }

        // Obtener la dirección hacia donde mira la cámara
        Vector3 direction = Camera.main.transform.forward;
        // Ignorar la dirección en el eje Y para evitar que el jugador vuele
        direction.y = 0f;
        // Normalizar la dirección para que tenga una magnitud de 1
        direction.Normalize();

        // Calcular la dirección del movimiento combinando la dirección hacia donde mira la cámara con la entrada del jugador
        Vector3 moveDirection = (direction * inputZ) + (Camera.main.transform.right * inputX);

        // Mover el personaje en la dirección calculada
        characterController.Move(moveDirection * velocidad * Time.deltaTime);
    }
}

