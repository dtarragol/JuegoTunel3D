using UnityEngine;

public class MovimientoPanel : MonoBehaviour
{
    public float velocidadMovimiento = 100f;
    public float alturaMaxima = 67f;
    public float alturaMinima = 32f;

    private RectTransform rectTransform;
    private float alturaActual = 32f;
    private bool subiendo = true;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (subiendo)
        {
            alturaActual += velocidadMovimiento * Time.deltaTime;
            if (alturaActual >= alturaMaxima)
            {
                alturaActual = alturaMaxima;
                subiendo = false;
            }
        }
        else
        {
            alturaActual -= velocidadMovimiento * Time.deltaTime;
            if (alturaActual <= alturaMinima)
            {
                alturaActual = alturaMinima;
                subiendo = true;
            }
        }

        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, alturaActual);
    }
}
