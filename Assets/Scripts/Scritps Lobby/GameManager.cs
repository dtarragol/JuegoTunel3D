using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject oso;

    private static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void ActivateOso()
    {
        instance.oso.SetActive(true);
    }
}