using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string levelSelect;
    public string mainMenu;
    private LevelManager levelManager;
    public GameObject pauseScreen;
    private PlayerController thePlayer;

    // Start is called before the first frame update
    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (Time.timeScale == 0)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }

    public void ResumeGame()
    {
        PauseGame(false);
    }

    public void LevelSelect()
    {

        PauseGame(false);

        PlayerPrefs.SetInt("coins", levelManager.coinCount);
        PlayerPrefs.SetInt("lives", levelManager.currentLives);
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        PauseGame(false);

        SceneManager.LoadScene(mainMenu);
    }

    private void PauseGame(bool paused)
    {
        if (paused)
        {
            Time.timeScale = 0;
            thePlayer.canMove = false;
            levelManager.levelMusic.Pause();
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            thePlayer.canMove = true;
            levelManager.levelMusic.Play();
            pauseScreen.SetActive(false);
        }
    }    
}
