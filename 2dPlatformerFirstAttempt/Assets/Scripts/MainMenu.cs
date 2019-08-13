using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string firstLevelToLoad;
    public string levelSelect;
    public string[] lockedLevels;
    public int startingLives;
    public Button continueButton;    

    // Start is called before the first frame update
    public void Start()
    {
        var lives = PlayerPrefs.GetInt("lives", 0);

        if (lives <= 0)
        {
            continueButton.enabled = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void NewGame()
    {
        foreach (var level in lockedLevels)
        {
            PlayerPrefs.SetInt(level, 0);
        }

        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("lives", startingLives);
        SceneManager.LoadScene(firstLevelToLoad);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
