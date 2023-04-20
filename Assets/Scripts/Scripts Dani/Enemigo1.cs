using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo1 : MonoBehaviour
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
    public Quaternion angulo;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
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
            ani.SetBool("ataque", true);
            Debug.Log("El enemigo ha tocado al jugador");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
             
                ani.SetBool("walk", false);
                if (estarAlerta == true)
                { rutina++; }

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
                ani.SetBool("walk", true);
                break;

        }
    }
}

