using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Image blackScreen;
    public float fadeSpeed;
    public bool fadeToBlack;
    public bool fadeFromBlack;

    //Imagen y texto vida
    public Text healthText;
    public Image healthImage;

    //Imagen y texto coche
    public Text carText;

    //menu de pausa
    public GameObject pauseScreen, optionsScreen;

    //Sliders de sonido
    public Slider musicVolSlider;
    public Slider sfxVolSlider;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /*if(fadeToBlack)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if(blackScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
		}*/
		/*if (fadeFromBlack)
			{
				blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

				if (blackScreen.color.a == 0f)
				{
					fadeFromBlack = false;
				}
			}*/
	}

    public void Resume()
    {
        GameManager.instance.PauseUnpase();
    }

    public void Options()
    {
        optionsScreen.SetActive(true);

    }

    public void CloseOptions()
    {
		optionsScreen.SetActive(false);
	}

    public void SetMusicLevel()
    {
        AudioManager.instance.SetMusicLevel();
    }

    public void SetSFXLevel()
    {
        AudioManager.instance.SetSFXLevel();
    }
}
