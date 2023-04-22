using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemigo : MonoBehaviour
{
    public int damage;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Player.GetComponent<DatosJugador>().vidaPlayer -= damage;
        }

        if (other.tag == "Enemigo")
        {
            UnityEngine.Debug.Log("Esto es un enemigo");
        }
    }
}
