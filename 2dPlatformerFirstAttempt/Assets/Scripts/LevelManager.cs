using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public PlayerController thePlayer;
    public GameObject deathsplosionEffect;

    // Start is called before the first frame update
    public void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();        
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void Respawn()
    {
        StartCoroutine("RespawnCo");
    }

    //Coroutine to respawn the player with a delay
    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);

        //fire particle effect
        Instantiate(deathsplosionEffect, thePlayer.transform.position, new Quaternion(thePlayer.transform.rotation.x + 90f, thePlayer.transform.rotation.y, thePlayer.transform.rotation.z, thePlayer.transform.rotation.w));

        yield return new WaitForSeconds(waitToRespawn);

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
        
    }
}
