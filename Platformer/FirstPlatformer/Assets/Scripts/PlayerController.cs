using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    private Animator myAnimator;

	// Use this for initialization
	void Start () {

        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //Grounded status
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //Left and right movement
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(0f, myRigidBody.velocity.y, 0f);
        }

        //Jumping
        if (Input.GetButtonDown("Jump") == true && isGrounded)
        {
            myRigidBody.velocity = new Vector3(myRigidBody.velocity.x, jumpSpeed, 0f);
        }

        //Animations        
        myAnimator.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x)); /* Abs returns absolute of a float, i.e. if the value is -5 it returns 5... 
        this is because we want to treat -5 x speed as greater than zero for our animations*/
        myAnimator.SetBool("Grounded", isGrounded);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillPlane")
        {
            gameObject.SetActive(false);
        }
    }
}
