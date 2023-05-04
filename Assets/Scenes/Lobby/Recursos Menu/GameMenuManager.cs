using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{

    public GameObject menu;
    public InputActionProperty showButton;

    // Añade una variable privada para guardar el estado anterior del timeScale
    private float previousTimeScale = 1f;

    void Start()
    {

    }

    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            // Si el menú está activado, pausa el juego
            if (menu.activeSelf)
            {
                previousTimeScale = Time.timeScale;
                Time.timeScale = 0f;
            }
            else // Si el menú está desactivado, reanuda el juego
            {
                Time.timeScale = previousTimeScale;
            }
        }
    }
}