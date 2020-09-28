using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int totalScenes;
    [SerializeField] float sceneLoadDelay = 2.5f;
    private Scene currentScene;
    private int currentSceneIndex;    

    // Start is called before the first frame update
    void Start()
    {
        totalScenes = SceneManager.sceneCountInBuildSettings;
        currentScene = SceneManager.GetActiveScene();
        currentSceneIndex = currentScene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug.isDebugBuild && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.L))
        {
            print("Debug key detected: Load next level");
            LoadNextScene(0.3f);
        }
    }

    internal void LoadNextScene(float delay = 0.0f)
    {        
        currentSceneIndex = currentScene.buildIndex;

        if (currentSceneIndex + 1 >= totalScenes)
        {
            print("Winner winner chicken dinner!!!"); //todo win screen
            LoadInitialScene(delay);         
            return;
        }

        if (delay <= Mathf.Epsilon)
        {
            Invoke(nameof(LoadNextSceneWithDelay), sceneLoadDelay);
        }
        else
        {
            Invoke(nameof(LoadNextSceneWithDelay), delay);
        }        
    }

    internal void LoadInitialScene(float delay = 0.0f)
    {
        if (delay <= Mathf.Epsilon)
        {
            Invoke(nameof(LoadSceneWithDelay), sceneLoadDelay);
        }
        else
        {
            Invoke(nameof(LoadSceneWithDelay), delay);
        }        
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
