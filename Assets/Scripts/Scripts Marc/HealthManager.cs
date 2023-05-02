using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Daño y maxima vida
    public static HealthManager instance;
    public int currentHealth, maxHealth;

    //Mode invencible despues de recibir daño
    public float invicibleLength = 2f;
    private float invincCounter;

    //Imagen marcador de vidas

    public Sprite[] healthBarImages;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetHealth();
		
	}

    
    void Update()
    {
        if(invincCounter > 0)
        {
			//Invencibilidad despues de recibir daño
			invincCounter -= Time.deltaTime;

            //Animación cuandor recibe daño
            for(int i = 0; i < Controles.instance.playerPieces.Length; i++)
            {
                if(Mathf.Floor(invincCounter * 5f) % 2 == 0)
                {
                    Controles.instance.playerPieces[i].SetActive(true);
                }
                else
                {
					Controles.instance.playerPieces[i].SetActive(false);
				}

				if (invincCounter <= 0)
				{
					Controles.instance.playerPieces[i].SetActive(true);
				}
			}

        }
    }

    public void Hurt()
    {
        if(invincCounter <= 0) 
        {
           
            currentHealth--;

            if(currentHealth <= 0)
            {

                currentHealth = 0;
                GameManager.instance.Respawn();

		    }
		    else
		    {
			    Controles.instance.Knockback();
                invincCounter = invicibleLength;
		    }
	    }
		UpdateUI();
	}

    public void ResetHealth()
    {
        currentHealth = maxHealth;
		UIManager.instance.healthImage.enabled = true;
		UpdateUI();
	}

    //Sumar vidas con objeto
	public void AddHealth(int amountToHeal)
	{
		currentHealth += amountToHeal;

		if (currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}

        UpdateUI();
	}

    public void UpdateUI()
    {

        UIManager.instance.healthText.text = currentHealth.ToString();

        switch (currentHealth)
        {
            case 5:
                UIManager.instance.healthImage.sprite = healthBarImages[4];
                break;
			case 4:
				UIManager.instance.healthImage.sprite = healthBarImages[3];
				break;
			case 3:
				UIManager.instance.healthImage.sprite = healthBarImages[2];
				break;
			case 2:
				UIManager.instance.healthImage.sprite = healthBarImages[1];
				break;
			case 1:
				UIManager.instance.healthImage.sprite = healthBarImages[0];
				break;
            case 0:
                UIManager.instance.healthImage.enabled = false;
                break;
		}

    }

    public void PlayerKilled()
    {
        currentHealth = 0;
        UpdateUI();
    }
}
