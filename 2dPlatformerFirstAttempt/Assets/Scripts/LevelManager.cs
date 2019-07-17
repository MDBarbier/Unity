using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public PlayerController thePlayer;
    public GameObject deathsplosionEffect;
    public GameObject hurtsplosionEffect;
    public int coinCount;
    public Text scoreText;
    public Image health1;
    public Image health2;
    public Image health3;
    public Sprite healthFull;
    public Sprite healthHalf;
    public Sprite healthEmpty;
    public int maxHealth;
    public int currentHealth;
    internal bool startedRespawn = false;
    public ResetOnRespawn[] resetOnRespawns;
    public bool invincible;
    private int currentLives;
    public int startingLives;
    public Text livesText;

    // Start is called before the first frame update
    public void Start() 
    {
        thePlayer = FindObjectOfType<PlayerController>();
        scoreText.text = "Score: 0000";
        currentHealth = 6;
        resetOnRespawns = FindObjectsOfType<ResetOnRespawn>();
        currentLives = startingLives;
        livesText.text = $"x {currentLives}";
    }

    // Update is called once per frame
    public void Update()
    {
       
    }

    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = $"x {currentLives}";

        //fire particle effect
        Instantiate(deathsplosionEffect, thePlayer.transform.position, new Quaternion(thePlayer.transform.rotation.x + 90f, thePlayer.transform.rotation.y, thePlayer.transform.rotation.z, thePlayer.transform.rotation.w));

        if (currentLives <= 0)
        {
            livesText.text = $"Game over!";
            thePlayer.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine("RespawnCo");
        }
    }

    //Coroutine to respawn the player with a delay
    public IEnumerator RespawnCo()
    {
        if (!startedRespawn)
        {
            startedRespawn = true;
            thePlayer.gameObject.SetActive(false);
           
            yield return new WaitForSeconds(waitToRespawn);

            currentHealth = maxHealth;
            startedRespawn = false;
            UpdateHealthMeter();
            invincible = true;
            thePlayer.transform.position = thePlayer.respawnPosition;
            thePlayer.gameObject.SetActive(true);

            thePlayer.transform.parent = null; //set the parent back to null in case player was made a child before dying

            //Reset objects
            foreach (var item in resetOnRespawns)
            {
                item.ResetObject();
            }
            
        }
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;        
        scoreText.text = $"Score: " + coinCount.ToString().PadLeft(4, '0');
    }

    public void HurtPlayer(int damageAmount)
    {
        if (!invincible)
        {
            currentHealth -= damageAmount;
            UpdateHealthMeter();

            thePlayer.Knockback();

            if (currentHealth <= 0 && !startedRespawn)
            {
                Respawn();
            }
            else
            {
                //fire particle effect
                Instantiate(hurtsplosionEffect, thePlayer.transform.position, new Quaternion(thePlayer.transform.rotation.x + 90f, thePlayer.transform.rotation.y, thePlayer.transform.rotation.z, thePlayer.transform.rotation.w));
            }
        }
    }

    public void UpdateHealthMeter()
    {
        switch (currentHealth)
        {
            case 6:
                health1.sprite = healthFull;
                health2.sprite = healthFull;
                health3.sprite = healthFull;
                break;
            case 5:
                health1.sprite = healthFull;
                health2.sprite = healthFull;
                health3.sprite = healthHalf;
                break;
            case 4:
                health1.sprite = healthFull;
                health2.sprite = healthFull;
                health3.sprite = healthEmpty;
                break;
            case 3:
                health1.sprite = healthFull;
                health2.sprite = healthHalf;
                health3.sprite = healthEmpty;
                break;
            case 2:
                health1.sprite = healthFull;
                health2.sprite = healthEmpty;
                health3.sprite = healthEmpty;
                break;
            case 1:
                health1.sprite = healthHalf;
                health2.sprite = healthEmpty;
                health3.sprite = healthEmpty;
                break;
            case 0:
                health1.sprite = healthEmpty;
                health2.sprite = healthEmpty;
                health3.sprite = healthEmpty;
                break;
            default:

                if (currentHealth <= 0)
                {
                    health1.sprite = healthEmpty;
                    health2.sprite = healthEmpty;
                    health3.sprite = healthEmpty;
                }
                else if (currentHealth >= maxHealth)
                {
                    health1.sprite = healthFull;
                    health2.sprite = healthFull;
                    health3.sprite = healthFull;
                }
                break;
        }
    }
}
