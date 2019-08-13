using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{    
    public string levelSelect;
    public string mainMenu;
    private LevelManager levelManager;

    // Start is called before the first frame update
    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("lives", levelManager.startingLives);
        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("lives", levelManager.startingLives);
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
