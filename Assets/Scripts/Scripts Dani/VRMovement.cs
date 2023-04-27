using UnityEngine;

public class VRMovement : MonoBehaviour
{
    public float velocidad = 1.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(inputX, 0, inputZ) * velocidad;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}