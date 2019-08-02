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
    public GameObject gameOverScreen;
    private int progressToNewLife;
    public AudioSource levelMusic;
    public AudioSource gameOverMusic;
    public AudioSource victorySound;
    public Image blackScreen;

    // Start is called before the first frame update
    public void Start() 
    {
        blackScreen.gameObject.SetActive(true);
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
        UpdateLivesText();

        //fire particle effect
        Instantiate(deathsplosionEffect, thePlayer.transform.position, new Quaternion(thePlayer.transform.rotation.x + 90f, thePlayer.transform.rotation.y, thePlayer.transform.rotation.z, thePlayer.transform.rotation.w));

        if (currentLives <= 0)
        {
            livesText.text = $"Game over!";
            levelMusic.Stop();
            gameOverMusic.Play();
            gameOverScreen.SetActive(true);
            thePlayer.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine("RespawnCo");
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = $"x {currentLives}";
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
        progressToNewLife += coinsToAdd;
        thePlayer.pickupCoinSound.Play();

        if (progressToNewLife >= 100)
        {
            AdjustLives(1);

            progressToNewLife -= 100;
        }

        scoreText.text = $"Score: " + coinCount.ToString().PadLeft(4, '0');
    }

    public void HurtPlayer(int damageAmount, bool updateHealthMeter)
    {
        if (!invincible)
        {
            currentHealth -= damageAmount;

            if (updateHealthMeter) UpdateHealthMeter();

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

    public void RestoreHealth(int healthToRestore, bool updateHealthMeter)
    {
        currentHealth = currentHealth + healthToRestore > maxHealth ? maxHealth : currentHealth + healthToRestore;

        if (updateHealthMeter) UpdateHealthMeter();
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

    public void AdjustLives(int livesToAdd)
    {
        currentLives += livesToAdd;
        UpdateLivesText();
    }
}
