using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAEscena0 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        GameManager.ActivateOso();
        }
    }
    
}