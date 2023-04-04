using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaActual;
    public float vidaMaxima;
    public GameObject Personaje;

    // Update is called once per frame
    void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Enemy") vidaActual -= 25;
    }
}
