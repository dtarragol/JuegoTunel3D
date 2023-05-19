using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicaBoton : MonoBehaviour
{
    public Button restartButton; // referencia al botón

    void Start()
    {
        // añadir el manejador de eventos al botón
        restartButton.onClick.AddListener(RestartCurrentScene);
    }

    // Método para reiniciar la escena
    void RestartCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // obtiene la escena activa
        SceneManager.LoadScene(currentScene.name); // carga la escena activa
    }

}
