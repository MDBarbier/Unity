using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int totalScenes;
    [SerializeField] float sceneLoadDelay = 1f;
    private Scene currentScene;
    private int currentSceneIndex;    

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneIndex = currentScene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void LoadNextScene()
    {        
        currentSceneIndex = currentScene.buildIndex;

        if (currentSceneIndex + 1 > totalScenes)
        {
            print("Winner winner chicken dinner!!!"); //todo win screen
            LoadInitialScene();         
            return;
        }

        Invoke(nameof(LoadNextSceneWithDelay), sceneLoadDelay);
    }

    internal void LoadInitialScene()
    {
        Invoke(nameof(LoadSceneWithDelay), sceneLoadDelay);
    }

    private void LoadNextSceneWithDelay()
    {   
        SceneManager.LoadScene(currentSceneIndex + 1);
    }   

    private void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(0);
    }
}
