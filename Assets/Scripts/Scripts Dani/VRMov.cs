using UnityEngine;

public class VRMov : MonoBehaviour
{
    public Transform vrCamera; // La c�mara de realidad virtual
    public float speed = 10.0f; // La velocidad de movimiento
    public float sensitivity = 0.1f; // La sensibilidad del joystick

    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Calcula la direcci�n de movimiento basado en el �ngulo del joystick
        Vector3 direction = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");

        // Rota la direcci�n basado en la rotaci�n de la c�mara
        direction = Quaternion.Euler(0, vrCamera.eulerAngles.y, 0) * direction;

        // Aplica la velocidad de movimiento a la direcci�n
        cc.Move(direction * speed * Time.deltaTime);
    }
}

