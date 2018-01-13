using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


    public float waitToRespawn;
    public PlayerController thePlayer;
    public GameObject deathExplosion;
    public int coinCount;

	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<PlayerController>();        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        StartCoroutine("RespawnCo"); //starts process off the main thread, if you used sleep it would hang the whole game until finished
    }

    private IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);

        Instantiate(deathExplosion, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        
        thePlayer.transform.position = thePlayer.respawnPoint;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
    }
}
