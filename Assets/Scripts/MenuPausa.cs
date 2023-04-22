using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausaOLobby;
    [SerializeField] private GameObject menuLobby;

    private bool juegoPausado = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                if (menuLobby.activeSelf)
                {
                    menuLobby.SetActive(false);
                }
                Reanudar();
            }
            else
            {
                if (!menuLobby.activeSelf)
                {
                    menuLobby.SetActive(true);
                }
                Pausa();
            }
        }
        if(menuLobby.activeSelf) 
        {
            botonPausa.SetActive(false);
            juegoPausado = true;
        }
        else
        {
            botonPausa.SetActive(true);
        }
    }

    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausaOLobby.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausaOLobby.SetActive(false);

    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
