using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    public string levelToLoad;
    private PlayerController thePlayer;
    private CameraController theCamera;
    private LevelManager levelManager;
    public float waitToMove;
    public float waitToLoad;
    private bool movePlayer;
    public Sprite openLevelEndFlag;
    public SpriteRenderer spriteRenderer;
    public string levelToUnlock;

    // Start is called before the first frame update
    public void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (movePlayer)
        {
            thePlayer.myRigidBody.velocity = new Vector3(thePlayer.moveSpeed, 0f, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            spriteRenderer.sprite = openLevelEndFlag;
            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
        StartCoroutine(FadeOut(levelManager.levelMusic, 2));
        levelManager.levelMusic.Stop();
        thePlayer.canMove = false;
        theCamera.followTarget = false;
        levelManager.invincible = true;
        thePlayer.myRigidBody.velocity = Vector3.zero;

        PlayerPrefs.SetInt("coins", levelManager.coinCount);
        PlayerPrefs.SetInt("lives", levelManager.currentLives);
        PlayerPrefs.SetInt(levelToUnlock, 1);

        yield return new WaitForSeconds(waitToMove);

        movePlayer = true;
        levelManager.victorySound.Play();

        yield return new WaitForSeconds(waitToLoad);

        levelManager.blackScreen.gameObject.SetActive(true);
        SceneManager.LoadScene(levelToLoad);
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
