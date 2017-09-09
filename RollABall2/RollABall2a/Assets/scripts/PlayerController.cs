using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //Public Variables (can be accessed from editor)
    public Rigidbody rb;
    public float speed;
    private int scoreCount;
    public Text scoreText;
    public Text winText;
    public Stopwatch stopwatch;

	// Use this for initialization
	void Start ()
    {

        //Try and find the rigidbody
        rb = GetComponent<Rigidbody>();

        //Set score initial
        scoreCount = 0;

        //Set score text
        SetScoreText();

        //Set victory message empty
        winText.text = "";

        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + scoreCount.ToString();

        if (scoreCount >= 16)
        {
            string timeTaken = stopwatch.Elapsed.Seconds.ToString() + "." + stopwatch.Elapsed.Milliseconds;
            winText.text = "Congratulations, you have collected all the shinies! You took " + timeTaken + " seconds!";
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    //Called whenever Physics is updated
    private void FixedUpdate()
    {
        //Gets the movement from the KB
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Add Force to RigidBody
        rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);

        
    }

    //Called when the player object collides with another object
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject); //This is how you could remove a GO completely and all children

        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            scoreCount++;
            SetScoreText();
        }
    }
}
