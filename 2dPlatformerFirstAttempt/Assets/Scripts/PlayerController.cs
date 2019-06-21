using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    public Vector3 respawnPosition;
    public LevelManager levelManager;

    // Start is called before the first frame update
    public void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>(); //gets the instance of the rigidbody for the player object
        myAnim = GetComponent<Animator>(); //gets the animator for the player
        levelManager = FindObjectOfType<LevelManager>();

        //set respawn
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        //check if the player is in contact with the ground, by checking if the radius we have specified to check is in contact with the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
        }

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x)); //sets animator speed as absolute (if player moving left X velocity will be treated as 5 not -5)
        myAnim.SetBool("Grounded", isGrounded);
    }

    public void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "KillPlane")
        {
            levelManager.Respawn();
        }
        else if (otherGameObject.tag == "Checkpoint")
        {
            respawnPosition = otherGameObject.transform.position;
        }
    }
}
