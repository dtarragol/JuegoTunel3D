using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public AnimationClip cinematic; // La cinem�tica que queremos reproducir
    public bool destroyOnCinematicEnd = true; // Indica si queremos destruir el objeto despu�s de reproducir la cinem�tica

    private bool isPlayingCinematic = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlayingCinematic)
        {
            isPlayingCinematic = true;
            StartCoroutine(PlayCinematic());
        }
    }

    IEnumerator PlayCinematic()
    {
        // Pausamos el tiempo
        Time.timeScale = 0f;

        // Reproducimos la cinem�tica en una animaci�n
        Animation animation = GetComponent<Animation>();
        animation.AddClip(cinematic, "Cinematic");
        animation.Play("Cinematic");

        // Esperamos a que termine la cinem�tica
        yield return new WaitForSecondsRealtime(cinematic.length);

        // Reanudamos el tiempo
        Time.timeScale = 1f;

        // Si indicamos que queremos destruir el objeto despu�s de reproducir la cinem�tica, lo destruimos
        if (destroyOnCinematicEnd)
        {
            Destroy(gameObject);
        }

        isPlayingCinematic = false;
    }
}