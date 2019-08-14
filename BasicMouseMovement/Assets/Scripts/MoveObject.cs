using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject objectToMove;
    public float moveForce;
    public Rigidbody rig;

    public void MoveTheObject()
    {
        Vector3 movement = new Vector3(moveForce, moveForce/2);
        //rig.AddForce(rig.transform.up * moveForce, ForceMode.Impulse);
        rig.AddForce(movement, ForceMode.Impulse);
    }
}
