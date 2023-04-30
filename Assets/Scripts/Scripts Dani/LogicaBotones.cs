using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaBotones : MonoBehaviour
{
    public Button salirBoton;
    public Button[] minijuegosBotones;
    public int[] minijuegosIndices;

    void Start()
    {
        salirBoton.onClick.AddListener(Salir);

        for (int i = 0; i < minijuegosBotones.Length; i++)
        {
            int index = i; // Necesario para que el valor de i se mantenga en la lambda

            minijuegosBotones[i].onClick.AddListener(() => IrAOtraEscena(minijuegosIndices[index]));
        }
    }

    void Salir()
    {
        Debug.Log("Saliendo de la aplicación.");
        Application.Quit();
    }

    void IrAOtraEscena(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}