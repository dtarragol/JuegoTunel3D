using UnityEngine;
using UnityEngine.UI;

public class BotonOpciones : MonoBehaviour
{
    public Canvas canvasActual;
    public Canvas canvasOpciones;

    private Button boton;

    private void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(ActivarOpciones);
    }

    private void ActivarOpciones()
    {
        canvasActual.gameObject.SetActive(false);
        canvasOpciones.gameObject.SetActive(true);
    }
}
