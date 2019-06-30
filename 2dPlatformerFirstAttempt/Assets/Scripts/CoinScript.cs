using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    private LevelManager theLevelManager;
    public int coinValue;

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
            theLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
