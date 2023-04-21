using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOver;
    public static GameOverManager gameOverManager;

    void Start()
    {
        gameOverManager = this;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallGameOver()
    {
        
        GameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
