using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnit : MonoBehaviour
{    
    private DetectMouse detectMouse;
    public GameObject[] units;
    public Material selectedUnitMaterial;
    public Material regularUnitMaterial;

    // Start is called before the first frame update
    public void Start()
    {
        detectMouse = FindObjectOfType<DetectMouse>();
        units = GameObject.FindGameObjectsWithTag("Unit");
    }

    // Update is called once per frame
    public void Update()
    {
        //Check selected unit
        if (detectMouse.clickDetectedOn == null)
        {

        }
        else if ( detectMouse.clickDetectedOn.gameObject.name != "Floor")
        {
            //Assign the "selected" material to the selected unit
            foreach (Transform childGO in detectMouse.clickDetectedOn.transform)
            {
                childGO.gameObject.GetComponent<MeshRenderer>().material = selectedUnitMaterial;
            }

            //Assign the "regular" unit material to all other Units
            foreach (var unit in units)
            {
                foreach (Transform childGO in unit.transform)
                {
                    if (childGO.transform.parent.name == detectMouse.clickDetectedOn.name)
                    {
                        continue;
                    }

                    childGO.gameObject.GetComponent<MeshRenderer>().material = regularUnitMaterial;
                }
            }
        }
        else
        {
            //Assign the "regular" unit material to all Units
            foreach (var unit in units)
            {
                foreach (Transform childGO in unit.transform)
                {
                    childGO.gameObject.GetComponent<MeshRenderer>().material = regularUnitMaterial;
                }
            }
        }

    }
}
