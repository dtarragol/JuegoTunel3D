using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
    public GameObject doorToDestroy; // referenciamos el objeto de la puerta en el Inspector
    public GameObject efecto; //Referenciamos el efecto
    private AudioSource audioSource; // Referenciamos el componente AudioSource

    private float delay = 1.7f; // La cantidad de tiempo (en segundos) que debe esperar antes de destruir los objetos

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); //Obtenemos el componente AudioSource del objeto que tiene este script
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play(); // Reproducimos el audio clip
            Destroy(doorToDestroy);
            // Espera un tiempo antes de destruir los objetos restantes
            StartCoroutine(DestroyDoorAndEffect());
        }
    }

    private IEnumerator DestroyDoorAndEffect()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject); // destruye el objeto de la llave
        Destroy(doorToDestroy);
        Destroy(efecto); // destruye el objeto de la puerta seleccionada
    }
}