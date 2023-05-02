using UnityEngine;

public class DestruirDespuesDeTiempo : MonoBehaviour
{
    public float tiempoDeEspera = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Destruye el objeto despu�s del tiempo de espera
        Invoke("DestruirObjeto", tiempoDeEspera);
    }

    void DestruirObjeto()
    {
        // Destruye el objeto al que se ha adjuntado el script
        Destroy(gameObject);
    }
}