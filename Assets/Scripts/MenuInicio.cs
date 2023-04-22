using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    [SerializeField] private GameObject camara;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject audio;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = true; // hacer visible el cursor
        Cursor.lockState = CursorLockMode.None; // desbloquear el cursor


        Time.timeScale = 0;
        menu.SetActive(true);
        camara.GetComponent<FirstPersonLook>().enabled = false;
        audio.GetComponent<FirstPersonAudio>().enabled = false;
    }

    public void HideMenu()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        camara.GetComponent<FirstPersonLook>().enabled = true;
        audio.GetComponent<FirstPersonAudio>().enabled = true;

    }
    public void JuegoMazmorra()
    {
        SceneManager.LoadScene("Segurridad");
    }
    public void JuegoTunelTerror()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
