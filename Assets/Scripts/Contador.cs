using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI tiempoText;
    public float totalTime = 90.0f; // 2 minutos en segundos
    private float timeLeft;


    void Start()
    {
        timeLeft = totalTime;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            SceneManager.LoadScene("Lobby");
        }

        tiempoText.text = "Tiempo restante: " + Mathf.RoundToInt(timeLeft);
    }


}
