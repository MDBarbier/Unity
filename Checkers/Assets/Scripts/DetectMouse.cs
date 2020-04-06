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
                    if (hit.transform.tag == "WhitePieces" || hit.transform.tag == "BlackPieces")
                    {
                        clickDetectedOn = hit.transform.parent.gameObject;
                        var parent = hit.transform.parent.gameObject;
                        var colour = hit.transform.tag == "WhitePieces" ? "White" : "Black";
                        Debug.Log($"The piece clicked was {colour}, and is in {parent.name}, {parent.transform.parent.name}");
                    }

                    clickDetectedOn = hit.transform.gameObject;
                }
            }
        }
    }
}
