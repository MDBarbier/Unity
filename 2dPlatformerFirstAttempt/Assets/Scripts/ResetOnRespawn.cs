using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnRespawn : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 startLocalScale;
    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    public void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startLocalScale = transform.localScale;

        
        myRigidBody = GetComponent<Rigidbody2D>() ?? null;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void ResetObject()
    {
        gameObject.SetActive(true);

        transform.position = startPosition;
        transform.rotation = startRotation;
        transform.localScale = startLocalScale;

        if (myRigidBody != null)
            myRigidBody.velocity = Vector3.zero;        
    }
}
