using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    public GameObject objetoActivar;
    public GameObject objetoARotar;
    public float rotacionY = 70f; // Ángulo de rotación en el eje Y
    public AudioClip clipMusicaMenu;
    public AudioClip clipMusicaAmbiente;
    private AudioSource audioSource;

    private void Start()
    {
        // Obtener la fuente de audio de la escena
        audioSource = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Quaternion rotacionActual = objetoARotar.transform.rotation;

            // Calculamos la rotación deseada en el eje Y
            Quaternion rotacionDeseada = Quaternion.Euler(0f, rotacionY, 0f);

            // Asignamos la rotación deseada al objeto
            objetoARotar.transform.rotation = rotacionDeseada;
            objetoActivar.SetActive(true);

            // Cambiar la música al clip de música de menú
            audioSource.clip = clipMusicaMenu;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoActivar.SetActive(false);

            // Cambiar la música al clip de música de ambiente
            audioSource.clip = clipMusicaAmbiente;
            audioSource.Play();
        }
    }
}