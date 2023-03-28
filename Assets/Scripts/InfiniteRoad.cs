using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public Transform start;
    public Transform[] roadSegments;
    public float segmentLength;
    public float speed = 10f; // velocidad del juego

    private int currentSegment = 0;
    private float distanceTraveled = 0f;

    private void Update()
    {
        // Mueve los segmentos de la carretera hacia adelante
        for (int i = 0; i < roadSegments.Length; i++)
        {
            roadSegments[i].position -= new Vector3(0, 0, Time.deltaTime * speed);
        }

        // Calcula la distancia recorrida por el personaje
        distanceTraveled += Time.deltaTime * speed;

        // Si el personaje ha recorrido la longitud del segmento actual, mueve ese segmento al final de la secuencia
        if (distanceTraveled >= segmentLength)
        {
            distanceTraveled = 0f;
            roadSegments[currentSegment].position = start.position + new Vector3(0, 0, (roadSegments.Length - 1) * segmentLength);
            currentSegment++;

            // Si llega al final de la secuencia, regresa al principio
            if (currentSegment >= roadSegments.Length)
            {
                currentSegment = 0;
            }
        }
    }
}
