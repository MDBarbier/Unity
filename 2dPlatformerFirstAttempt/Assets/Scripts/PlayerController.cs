using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //sets the speed for horizontal movement
    public float jumpSpeed; //sets the speed for jumping movement
    private Rigidbody2D myRigidBody; //how the player object interacts with the physics engine
    public Transform groundCheck; //used to check if player is in contact with the gorund, assigned to a point at player's feet
    public float groundCheckRadius; //radius from bottom of player to check for ground
    public LayerMask whatIsGround; //defines what is the ground, i.e. the Layer called "Ground"
    public bool isGrounded; //tracks whether or not the player is grounded
    private Animator myAnim; //reference to the animator for the player
    public Vector3 respawnPosition; //the position for the player to respawn in
    public LevelManager levelManager; //reference to the level manager so we can interact with it
    public MovingObject[] theMovingObjects; //get all moving objects into an array
    public GameObject stompBox; //reference to player stompbox
    public float knockbackForce; //how much force the player gets knocked back when hitting a danger
    public float knockbackLength; //duration of knockback effect
    private float knockbackCounter; //duration of knockback effect
    public float invincibilityLength;
    private float invincibilityCounter;
    public AudioSource jumpSound;
    public AudioSource pickupCoinSound;

    // Start is called before the first frame update
    public void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>(); //gets the instance of the rigidbody for the player object
        myAnim = GetComponent<Animator>(); //gets the animator for the player
        levelManager = FindObjectOfType<LevelManager>(); //there's only one
        theMovingObjects = FindObjectsOfType<MovingObject>(); //get a list of all moving objects 

        //set respawn
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        //check if the player is in contact with the ground, by checking if the radius we have specified to check is in contact with the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //Only allow player control if they are not currently being knocked back
        if (knockbackCounter <= 0)
        {
            if (invincibilityCounter <= 0)
            {
                levelManager.invincible = false;
            }
            else
            {
                invincibilityCounter -= Time.deltaTime;
                Debug.Log($"Player has {invincibilityCounter} of invincibility remaining");
            }

            HandlePlayerInput();
        }
        else
        {
            knockbackCounter -= Time.deltaTime;

            if (transform.localScale.x > 0)
            {
                myRigidBody.velocity = new Vector3(-knockbackForce, (knockbackForce / 5) * 3, 0f);
            }
            else
            {
                myRigidBody.velocity = new Vector3(knockbackForce, (knockbackForce / 5) * 3, 0f);
            }           
        }

        //Sets up animator
        myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x)); //sets animator speed as absolute (if player moving left X velocity will be treated as 5 not -5)
        myAnim.SetBool("Grounded", isGrounded);
    }

    private void HandlePlayerInput()
    {
        //if player is falling, activate stomp box
        if (myRigidBody.velocity.y < 0)
        {
            stompBox.SetActive(true);
        }
        else
        {
            stompBox.SetActive(false);
        }

        //Handle horizontal movement
        if (Input.GetAxisRaw("Horizontal") > 0f) //moving right
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
            this.transform.localScale = new Vector3(1f, 1f, 1f); //every unity gameobject has a transform so we don't need to look for it
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f) //moving left
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
            this.transform.localScale = new Vector3(-1f, 1f, 1f); //every unity gameobject has a transform so we don't need to look for it
        }
        else
        {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
        }

        //Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpSound.Play();
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
        }
    }

    public void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "KillPlane" && levelManager.startedRespawn == false)
        {
            levelManager.Respawn();
        }
        else if (otherGameObject.tag == "Checkpoint")
        {
            respawnPosition = otherGameObject.transform.position;
        }
    }

    //Handles when the player leaves a collisiont with another collider
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            foreach (var movingObject in theMovingObjects)
            {
                if (movingObject.name == other.gameObject.transform.parent.name)
                {
                    Debug.Log($"Found the moving object {other.gameObject.transform.parent.name} which has a movespeed of {movingObject.moveSpeed}");
                }
            }

            transform.parent = other.transform;
        }
    }

    //Handles when the player leaves a collisiont with another collider
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            if (gameObject.activeSelf) //check if the go is active because you can't change parent in the same frame as it was activated/deactivated
                transform.parent = GameObject.Find("-----------Player").transform;
        }
    }

    public void Knockback()
    {
        invincibilityCounter = invincibilityLength;
        levelManager.invincible = true;

        if (isGrounded)
        {            
            knockbackCounter = knockbackLength;
        }
    }
}
