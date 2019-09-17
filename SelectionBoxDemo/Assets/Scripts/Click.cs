using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickablesLayer;

    private List<GameObject> selectedObjects;

    // Start is called before the first frame update
    public void Start()
    {
        selectedObjects = new List<GameObject>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycastHit, Mathf.Infinity, clickablesLayer))
            {
                var clickOn = raycastHit.collider.GetComponent<ClickOn>();

                if (Input.GetKey("left ctrl"))
                {
                    if (!clickOn.currentlySelected)
                    {
                        selectedObjects.Add(raycastHit.collider.gameObject);
                        clickOn.currentlySelected = true;
                        clickOn.ClickMe();
                    }
                    else
                    {
                        selectedObjects.Remove(raycastHit.collider.gameObject);
                        clickOn.currentlySelected = false;
                        clickOn.ClickMe();
                    }
                }
                else
                {
                    foreach (var item in selectedObjects)
                    {
                        var clickOnLocal = item.GetComponent<ClickOn>();
                        clickOnLocal.currentlySelected = false;
                        clickOnLocal.ClickMe();
                    }

                    selectedObjects.Clear();

                    selectedObjects.Add(raycastHit.collider.gameObject);
                    clickOn.currentlySelected = true;
                    clickOn.ClickMe();
                }                
            }
        }
    }
}
