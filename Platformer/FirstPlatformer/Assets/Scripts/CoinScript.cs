using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public int coinValue;
    public LevelManager theLevelManager;

    // Use this for initialization
    void Start () {

        theLevelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            theLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
