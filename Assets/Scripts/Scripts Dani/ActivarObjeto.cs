using UnityEngine;

public class ActivarObjeto : MonoBehaviour
{
    public GameObject objetoActivar;
    public GameObject objetoARotar;
    public float rotacionY = 70f; // �ngulo de rotaci�n en el eje Y
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

            // Calculamos la rotaci�n deseada en el eje Y
            Quaternion rotacionDeseada = Quaternion.Euler(0f, rotacionY, 0f);

            // Asignamos la rotaci�n deseada al objeto
            objetoARotar.transform.rotation = rotacionDeseada;
            objetoActivar.SetActive(true);

            // Cambiar la m�sica al clip de m�sica de men�
            audioSource.clip = clipMusicaMenu;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoActivar.SetActive(false);

            // Cambiar la m�sica al clip de m�sica de ambiente
            audioSource.clip = clipMusicaAmbiente;
            audioSource.Play();
        }
    }
}