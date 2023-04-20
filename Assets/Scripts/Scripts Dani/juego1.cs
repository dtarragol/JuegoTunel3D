using UnityEngine;
using UnityEngine.SceneManagement;

public class juego1 : MonoBehaviour
{
   
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Segurridad");
        }
    }

 
}