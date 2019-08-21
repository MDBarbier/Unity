using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            Vector3 adjustedNewPosition = Camera.main.transform.TransformPoint(newPosition);

            transform.position = adjustedNewPosition; 
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 newPosition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            //Vector3 adjustedNewPosition = Camera.main.transform.TransformPoint(newPosition);

            transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            //Vector3 adjustedNewPosition = Camera.main.transform.TransformPoint(newPosition);

            transform.position = newPosition;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 newPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            //Vector3 adjustedNewPosition = Camera.main.transform.TransformPoint(newPosition);

            transform.position = newPosition;
        }

    }
}
