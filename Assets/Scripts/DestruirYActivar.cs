using UnityEngine;
using System.Collections;

public class DestruirYActivar : MonoBehaviour
{
    public GameObject objetoADestruir;
    public GameObject objetoAActivar;

    private void Start()
    {
        // Iniciar una corrutina para destruir el objeto y activar otro después de 12 segundos
        StartCoroutine(DestruirYActivarDespuesDeEspera(12f));
    }

    IEnumerator DestruirYActivarDespuesDeEspera(float espera)
    {
        // Esperar durante el tiempo especificado
        yield return new WaitForSeconds(espera);

        // Destruir el objeto especificado y activar el otro objeto especificado
        if (objetoADestruir)
        {
            Destroy(objetoADestruir);
        }

        if (objetoAActivar)
        {
            objetoAActivar.SetActive(true);
        }
    }
}