using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite flagClosed;
    public Sprite flagOpen;
    private SpriteRenderer spriteRenderer;
    public bool checkpointActive;

    // Start is called before the first frame update
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    
    public void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "Player")
        {
            spriteRenderer.sprite = flagOpen;
            checkpointActive = true;
        }
    }
}
