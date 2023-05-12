using UnityEngine;

public class Enemigo_david : MonoBehaviour
{
    public float rangoAlerta;
    public LayerMask capaJugador;
    bool estarAlerta;
    public Transform jugador;
    public float velocidad;

    public float grado;
    public int rutina;
    public float crono;
    public Animator ani;
    private Quaternion angulo;
    public Vector3 teleportPosition;
    private CharacterController characterController;
    private bool isDisabled = false;
    public Vector3 posicionInicial;
   

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        // Obtén la referencia del jugador si no se ha asignado en el inspector
        if (!jugador)
        {
            jugador = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
        estarAlerta = Physics.CheckSphere(transform.position, rangoAlerta, capaJugador);

        if (estarAlerta == true)
        {
            Vector3 PosJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(PosJugador);
            transform.position = Vector3.MoveTowards(transform.position, PosJugador, velocidad * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAlerta);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("El enemigo ha tocado al jugador");
          
            //DisableCharacterController();
            //Debug.Log("Teleporting player to position: " + teleportPosition);
            // jugador.transform.position = teleportPosition;
            //transform.position = posicionInicial;
            //Invoke("EnableCharacterController", 1.0f);

        }
    }

    private void DisableCharacterController()
    {
        characterController = jugador.GetComponent<CharacterController>();
        if (characterController)
        {
            characterController.enabled = false;
            isDisabled = true;
        }
    }

    private void EnableCharacterController()
    {
        if (characterController)
        {
            characterController.enabled = true;
            isDisabled = false;
        }
    }

    public void Comportamiento_Enemigo()
    {
        crono += 1 * Time.deltaTime;
        if (crono >= 4)
        {
            rutina = Random.Range(0, 2);
            crono = 0;
        }
        switch (rutina)
        {
            case 0:
                if (estarAlerta == true)
                {
                    rutina++;
                }
                break;

            case 1:
                if (estarAlerta == true)
                {
                    Vector3 PosJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
                    transform.LookAt(PosJugador);
                    transform.position = Vector3.MoveTowards(transform.position, PosJugador, velocidad * Time.deltaTime);
                }
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;

            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                break;
        }
    }
}