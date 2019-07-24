using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeScript : MonoBehaviour
{
    public int numberOfLivesToGive;
    private LevelManager theLevelManager;

    // Start is called before the first frame update
    public void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();   
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.thePlayer.pickupCoinSound.Play();
            theLevelManager.AdjustLives(numberOfLivesToGive);
            gameObject.SetActive(false);
        }
    }
}
