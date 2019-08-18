using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* Lateral movement */
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + cameraMoveSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - cameraMoveSpeed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + cameraMoveSpeed);
        }
        /*end lateral movement*/


        /*vertical movement */
        if (Input.GetKey(KeyCode.PageUp))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + cameraMoveSpeed, transform.position.z);
        }

        if (Input.GetKey(KeyCode.PageDown))
        {
            if (transform.position.y > 3)
                transform.position = new Vector3(transform.position.x, transform.position.y - cameraMoveSpeed, transform.position.z);
        }
        /*vertical movement */


        /*horizontal pivot movement */

        if (Input.GetKey(KeyCode.Home))
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y + cameraMoveSpeed/5, transform.rotation.z, transform.rotation.w);
        }

        if (Input.GetKey(KeyCode.End))
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y - cameraMoveSpeed/5, transform.rotation.z, transform.rotation.w);
        }

        /* end horizontal pivot movement */
    }
}
