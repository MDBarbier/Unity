using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = this.transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    //Guaranteed to run after each object for the frame (better for follow camera,last known states, player information)
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
