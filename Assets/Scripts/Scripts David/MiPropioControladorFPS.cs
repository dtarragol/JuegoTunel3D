using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using System.Security.Cryptography;
using UnityEngine;

public class MiPropioControladorFPS : MonoBehaviour
{
    Rigidbody rb;
    Vector2 inputMov;
    Vector2 inputRot;
    public float velCamina = 10f;
    public float velCorre = 20f;
    public float fuerzaSalto = 10f;
    public float sensibilidadMouse = 1;

    Transform cam;
    float rotX;

    Vector3 escalaNormal;
    Vector3 escalaAgachado;
    bool agachado;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0);
        rotX = cam.eulerAngles.x;

        escalaNormal = transform.localScale;
        escalaAgachado = escalaNormal;
        escalaAgachado.y = escalaNormal.y * .75f;
    }

    // Update is called once per frame
    void Update()
    {
        //leemos el input
        inputMov.x = Input.GetAxis("Horizontal");
        inputMov.y = Input.GetAxis("Vertical");

        inputRot.x = Input.GetAxis("Mouse X") * sensibilidadMouse;
        inputRot.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        agachado = Input.GetKey(KeyCode.C);

        //salto

        if(Input.GetButtonDown("Jump") && !agachado) rb.AddForce(0,fuerzaSalto,0);



    }

    private void FixedUpdate()
    {
        //usamos ese input para movernos y girar
        float vel = Input.GetKey(KeyCode.LeftShift) ? velCorre : velCamina;
        rb.velocity = 
            transform.forward * vel * inputMov.y //mover hacia delante y atras 
            + transform.right * vel * inputMov.x //mover derecha izquierda
            + new Vector3 (0, rb.velocity.y, 0)
            ;
        transform.rotation *= Quaternion.Euler(0f, inputRot.x, 0f);//rotar horizontalmente
        //mirar hacia arriba y hacia abajo
        rotX -= inputRot.y;
        rotX = Mathf.Clamp(rotX, -50, 50);
        cam.localRotation  = Quaternion.Euler(rotX, 0, 0);

        //agacharse y erguirse

        transform.localScale = Vector3.Lerp(
            transform.localScale, 
            agachado ? escalaAgachado : escalaNormal, 
            .1f
        );
    }
}
