using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public AnimationClip cinematic; // La cinemática que queremos reproducir
    public bool destroyOnCinematicEnd = true; // Indica si queremos destruir el objeto después de reproducir la cinemática

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

        // Reproducimos la cinemática en una animación
        Animation animation = GetComponent<Animation>();
        animation.AddClip(cinematic, "Cinematic");
        animation.Play("Cinematic");

        // Esperamos a que termine la cinemática
        yield return new WaitForSecondsRealtime(cinematic.length);

        // Reanudamos el tiempo
        Time.timeScale = 1f;

        // Si indicamos que queremos destruir el objeto después de reproducir la cinemática, lo destruimos
        if (destroyOnCinematicEnd)
        {
            Destroy(gameObject);
        }

        isPlayingCinematic = false;
    }
}