using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosJugador : MonoBehaviour
{
   public int vidaPlayer;
   public Slider vidaVisual; 


   /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo")) 
        {
            Debug.Log("Jugador dañado por el enemigo");
        }
    }*/

    private void Update ()
    {
        vidaVisual.GetComponent<Slider>().value = vidaPlayer;

        if(vidaPlayer <=0)
        {
            Debug.Log("GAME OVER");
            Time.timeScale = 0f;
            GameOverManager.gameOverManager.CallGameOver();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
