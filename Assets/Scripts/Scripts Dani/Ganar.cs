using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
   
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("lobby");
        }
    }

 
}