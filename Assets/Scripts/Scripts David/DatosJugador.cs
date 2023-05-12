using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
   public int vidaPlayer;
   public Slider vidaVisual;
    public GameObject objetoactivar;
    public GameObject objetodesactivar;

   /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo")) 
        {
            Debug.Log("Jugador da�ado por el enemigo");
        }
    }*/

    private void Update ()
    {
        vidaVisual.GetComponent<Slider>().value = vidaPlayer;

        if(vidaPlayer <=0)
        {
            Time.timeScale = 0f;
            objetoactivar.SetActive(true);
            objetodesactivar.SetActive(false);
            //GameOverManager.gameOverManager.CallGameOver();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
