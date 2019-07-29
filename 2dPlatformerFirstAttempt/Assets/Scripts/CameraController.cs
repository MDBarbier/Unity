using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; //The target object for the samera
    public float leadTargetAmount; //the amount the camera should lead the target by
    private Vector3 cameraTarget; //target for the camera to follow
    public float cameraMoveSpeed;
    public bool followTarget;

    // Start is called before the first frame update
    public void Start()
    {
        followTarget = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (followTarget)
        {

            cameraTarget = new Vector3(target.transform.position.x, transform.position.y, transform.position.z); //we use the x axis position of the target, but keep the y and z axis the same

            if (target.transform.localScale.x > 0f)
            {
                //facing right
                cameraTarget = new Vector3(cameraTarget.x + leadTargetAmount, cameraTarget.y, cameraTarget.z);

            }
            else
            {
                //facing left
                cameraTarget = new Vector3(cameraTarget.x - leadTargetAmount, cameraTarget.y, cameraTarget.z);

            }

            //We use Lerp to move the camera smoothly
            //Time.deltaTime is a way to account for different speed cpus
            transform.position = Vector3.Lerp(transform.position, cameraTarget, cameraMoveSpeed * Time.deltaTime);
        }
    }
}
