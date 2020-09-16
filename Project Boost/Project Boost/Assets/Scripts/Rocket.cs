using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField]
    float lateralRotation = 2.5f;

    [SerializeField]
    float thrust = 3f;

    private bool crashed = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        HandleThrust();
        HandleLateralRotation();
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.gameObject.tag)
        {       
            case "Friendly":
                print("Touchdown!");
                break;
            case "Hazard":
            default:
                crashed = true;
                print("BOOOOOM");
                break;
        }
    }

    private void HandleLateralRotation()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation

        var rotation = lateralRotation * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            if (crashed)
                return;

            transform.Rotate(Vector3.forward * rotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (crashed)
                return;

            transform.Rotate(Vector3.forward * -rotation);
        }

        rigidBody.freezeRotation = false; //release manual control of rotation
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (crashed)
                return;

            rigidBody.AddRelativeForce(new Vector3(0f, thrust, 0f));

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
