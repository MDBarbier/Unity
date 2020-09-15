using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    
    [SerializeField]
    public float lateralRotation = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {        
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(new Vector3(0f, 1.5f, 0f));            
        }

        var rotation = lateralRotation * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {            
            transform.Rotate(new Vector3(0f, 0f, rotation));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0f, 0f, -rotation));
        }
    }
}
