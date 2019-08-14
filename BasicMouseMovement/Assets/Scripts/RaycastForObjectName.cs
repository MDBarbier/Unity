using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForObjectName : MonoBehaviour
{
    private Vector3 targetPosition;
    private Camera mainCamera;
    private Rigidbody rig;
    private MoveObject moveObjectScript;

    // Start is called before the first frame update
    public void Start()
    {
        mainCamera = Camera.main;
        moveObjectScript = FindObjectOfType<MoveObject>();
    }

    // Update is called once per frame
    public void Update()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform)
                {
                    Debug.Log($"Ray hit: {hit.transform.gameObject}");

                    if (rig = hit.transform.GetComponent<Rigidbody>())
                    {                        
                        moveObjectScript.MoveTheObject();
                    }
                }
            }
        }
    }
}
