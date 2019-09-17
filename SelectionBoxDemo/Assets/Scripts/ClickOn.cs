using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Material red;

    [SerializeField]
    private Material gold;

    private MeshRenderer meshRenderer;

    [HideInInspector]
    public bool currentlySelected = false;

    // Start is called before the first frame update
    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void ClickMe()
    {
        if (!currentlySelected)
        {
            meshRenderer.material = red;
        }
        else
        {
            meshRenderer.material = gold;
        }
    }
}
