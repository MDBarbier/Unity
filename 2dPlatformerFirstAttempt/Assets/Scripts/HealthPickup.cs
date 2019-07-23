using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToGive;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelManager.RestoreHealth(healthToGive, true);
            gameObject.SetActive(false);
        }
    }
}
