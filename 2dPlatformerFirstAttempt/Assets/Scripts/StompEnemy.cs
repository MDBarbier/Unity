using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour
{

    public GameObject deathsplosionEffect;

    // Start is called before the first frame update
    public void Start()
    {
        
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

            Destroy(other.gameObject);
        }
    }
}
