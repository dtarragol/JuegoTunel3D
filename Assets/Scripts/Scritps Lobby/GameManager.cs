using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    

	public Vector3 respawnPosition;

	//Efecto muerte
	public GameObject deathEffect;

	//Piezas a recoger
	public int currentCoins;

	public static GameManager instance;

    public void Awake()
    {
		instance = this;

		if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }


	void Start()
	{
		//Cursor invible, solo aparece con ESC

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		respawnPosition = Controles.instance.transform.position;

		AddCoins(0);

	}

	public static void ActivateOso()
    {
        
    }
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			PauseUnpase();
		}
	}

	public void Respawn()
	{

		StartCoroutine(RespawnWaiter());
		HealthManager.instance.PlayerKilled();

	}

	public IEnumerator RespawnWaiter()
	{
		Controles.instance.gameObject.SetActive(false);

		CameraController.instance.cmBrain.enabled = false;

		UIManager.instance.fadeToBlack = true;

		Instantiate(deathEffect, Controles.instance.transform.position + new Vector3(0f, 1f, 0f), Controles.instance.transform.rotation);

		yield return new WaitForSeconds(2f);

		UIManager.instance.fadeFromBlack = true;

		Controles.instance.transform.position = respawnPosition;
		CameraController.instance.cmBrain.enabled = true;
		Controles.instance.gameObject.SetActive(true);

		//Respawn de las vidas al morir

		HealthManager.instance.ResetHealth();
	}

	public void AddCoins(int coinsToAdd)
	{
		currentCoins += coinsToAdd;
		UIManager.instance.carText.text = "" + currentCoins;
	}

	//Activar y desactivar menu pausa
	public void PauseUnpase()
	{
		if (UIManager.instance.pauseScreen.activeInHierarchy)
		{
			UIManager.instance.pauseScreen.SetActive(false);
			Time.timeScale = 1f;


			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
		else
		{
			UIManager.instance.pauseScreen.SetActive(true);
			UIManager.instance.CloseOptions();
			Time.timeScale = 0f;


			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}