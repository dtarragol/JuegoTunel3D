using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public float rangoDeAlerta;
    
    public LayerMask capaDelJugador;
    
    public Transform Jugador;

    public float velocidad;

    bool estarAlerta;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);   

        if (estarAlerta == true)
        {
            //transform.LookAt(Jugador);
            Vector3 posJugador = new Vector3(Jugador.position.x, transform.position.y, Jugador.position.z);
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position,posJugador, velocidad * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }
}
