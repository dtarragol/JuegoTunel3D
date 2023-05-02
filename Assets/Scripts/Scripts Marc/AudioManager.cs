using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] music;
    public AudioSource[] sfx;

    public AudioMixerGroup musicMixer;
    public AudioMixerGroup sfxMixer;


    private void Awake()
    {
       instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Play();
    }

	public void SetMusicLevel()
	{
        musicMixer.audioMixer.SetFloat("MusicVol", UIManager.instance.musicVolSlider.value);
	}

	public void SetSFXLevel()
	{
        sfxMixer.audioMixer.SetFloat("SfxVol", UIManager.instance.sfxVolSlider.value);
	}
}
