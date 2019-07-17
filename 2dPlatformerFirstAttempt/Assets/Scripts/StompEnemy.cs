using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour
{

    public GameObject deathsplosionEffect;
    private Rigidbody2D playerRigidBody;
    public float bounceForce;

    // Start is called before the first frame update
    public void Start()
    {
        playerRigidBody = transform.parent.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //fire particle effect
            Instantiate(deathsplosionEffect, other.gameObject.transform.position, new Quaternion(other.gameObject.transform.rotation.x + 90f, other.gameObject.transform.rotation.y, 
                other.gameObject.transform.rotation.z, other.gameObject.transform.rotation.w));

            playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, bounceForce, 0f);

            other.gameObject.SetActive(false);
        }
    }
}
