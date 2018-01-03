﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    public float lifetime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        lifetime = lifetime - Time.deltaTime;

        if (lifetime <= 0f)
        {
            Destroy(gameObject);
        }
	}
}
