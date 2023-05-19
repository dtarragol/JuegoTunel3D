using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicaBoton : MonoBehaviour
{
    public Button restartButton; // referencia al bot�n

    void Start()
    {
        // a�adir el manejador de eventos al bot�n
        restartButton.onClick.AddListener(RestartCurrentScene);
    }

    // M�todo para reiniciar la escena
    void RestartCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // obtiene la escena activa
        SceneManager.LoadScene(currentScene.name); // carga la escena activa
    }

}
