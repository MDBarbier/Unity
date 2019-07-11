using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozeController : MonoBehaviour
{
    public Transform leftPatrolLimit;
    public Transform rightPatrolLimit;
    public float moveSpeed;
    private Rigidbody2D myRigidBody;
    public Direction moveDirection;

    // Start is called before the first frame update
    public void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (moveDirection == Direction.Right && transform.position.x >= rightPatrolLimit.position.x)
        {
            moveDirection = Direction.Left;
        }
        else if (moveDirection == Direction.Left && transform.position.x <= leftPatrolLimit.position.x)
        {
            moveDirection = Direction.Right;
        }
        
        if (moveDirection == Direction.Right)
        {
            myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f);
        }
    }

    public enum Direction
    {
        Left,Right
    }
}
