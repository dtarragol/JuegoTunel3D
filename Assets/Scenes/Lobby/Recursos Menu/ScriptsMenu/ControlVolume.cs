using UnityEngine;
using UnityEngine.UI;

public class ControlVolume : MonoBehaviour
{
    public Slider slider;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider.onValueChanged.AddListener(CambiarVolumen);
    }

    private void CambiarVolumen(float valor)
    {
        audioSource.volume = valor;
    }
}