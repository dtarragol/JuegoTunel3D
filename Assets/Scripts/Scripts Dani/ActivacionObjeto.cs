using UnityEngine;

public class ActivacionObjeto : MonoBehaviour
{
    public GameObject objetoActivar;
    public GameObject objetoSiguiente;
    private GameObject objetoActual;

    private void Start()
    {
        // Al iniciar el script, el objeto actual es el objeto a activar
        objetoActual = objetoActivar;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objetoActual.SetActive(false); // Desactivas el objeto actual
            objetoSiguiente.SetActive(true); // Activas el objeto siguiente
            objetoActual = objetoSiguiente; // Actualizas el objeto actual
        }
    }
}