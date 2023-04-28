using UnityEngine;

using UnityEngine;

public class DestruirObjeto : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si la colisi�n se produce con el jugador
        if (other.CompareTag("Player"))
        {
            // Destruye el objeto al que est� unido este script
            Destroy(gameObject);
        }
    }
}