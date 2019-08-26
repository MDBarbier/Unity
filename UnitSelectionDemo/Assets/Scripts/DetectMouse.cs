using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouse : MonoBehaviour
{    
    private Camera mainCamera;
    internal GameObject clickDetectedOn;

    // Start is called before the first frame update
    public void Start()
    {
        mainCamera = Camera.main;        
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
                    clickDetectedOn = hit.transform.gameObject;

                    if (hit.transform.tag == "ChildObject")
                    {
                        clickDetectedOn = hit.transform.parent.gameObject;
                        Debug.Log($"Parent object is {hit.transform.parent.gameObject.name}");
                    }
                }
            }
        }
    }
}
