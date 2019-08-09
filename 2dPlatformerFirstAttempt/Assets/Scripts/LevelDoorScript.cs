using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoorScript : MonoBehaviour
{
    public string levelToLoad;
    public bool doorUnlocked;
    public Sprite doorBottomOpen;
    public Sprite doorTopOpen;
    public Sprite doorBottomClosed;
    public Sprite doorTopClosed;

    public SpriteRenderer doorTop;
    public SpriteRenderer doorBottom;
    
    // Start is called before the first frame update
    public void Start()
    {
        PlayerPrefs.SetInt("Level1", 1);

        if (PlayerPrefs.GetInt(levelToLoad) == 1)
        {
            doorUnlocked = true;
            doorTop.sprite = doorTopOpen;
            doorBottom.sprite = doorBottomOpen;
        }
        else
        {
            doorUnlocked = false;
            doorTop.sprite = doorTopClosed;
            doorBottom.sprite = doorBottomClosed;
        }                
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if ((Input.GetButtonDown("Vertical")) && doorUnlocked)
            {
                SceneManager.LoadScene(levelToLoad);
            }

        }
    }
}
