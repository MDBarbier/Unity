using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float waitToRespawn;
    public PlayerController thePlayer;

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

        yield return new WaitForSeconds(waitToRespawn);

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
        
    }
}
