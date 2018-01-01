using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Sprite flagClosed;
    public Sprite flagOpen;
    public bool checkPointActive;
    private SpriteRenderer spriteRenderer;


	// Use this for initialization
	void Start () {

        spriteRenderer = GetComponent<SpriteRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {		

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spriteRenderer.sprite = flagOpen;
            checkPointActive = true;
        }
    }
}
