using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject obectToMove;
    public float moveSpeed;
    private Vector3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = endPoint.position;        
    }

    // Update is called once per frame
    void Update()
    {
        obectToMove.transform.position = Vector3.MoveTowards(obectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

        if (obectToMove.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }
        else if (obectToMove.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }
    }
}
