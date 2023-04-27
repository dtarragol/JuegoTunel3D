using UnityEngine;

public class VRMov : MonoBehaviour
{
    public Transform vrCamera; // La cámara de realidad virtual
    public float speed = 10.0f; // La velocidad de movimiento
    public float sensitivity = 0.1f; // La sensibilidad del joystick

    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Calcula la dirección de movimiento basado en el ángulo del joystick
        Vector3 direction = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");

        // Rota la dirección basado en la rotación de la cámara
        direction = Quaternion.Euler(0, vrCamera.eulerAngles.y, 0) * direction;

        // Aplica la velocidad de movimiento a la dirección
        cc.Move(direction * speed * Time.deltaTime);
    }
}

