using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float moveSpeed;
    private bool enemyActivated;

    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    public void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    public void Update()
    {
        if (enemyActivated)
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
        }
    }

    public void OnBecameVisible()
    {
        enemyActivated = true;
    }

    public void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }
}
