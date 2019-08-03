using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoorScript : MonoBehaviour
{
    public string levelToLoad;
    
    // Start is called before the first frame update
    public void Start()
    {
                
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene(levelToLoad);
            }

        }
    }
}
