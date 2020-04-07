using System;
using System.Linq;
using UnityEngine;

public class SelectPiece : MonoBehaviour
{
    private DetectMouse detectMouse;
    private SceneManager sceneManager;
    private CalculateLegalMoves calculateLegalMoves;
    public GameObject[] pieces;
    public Material whitePieceMaterial;
    public Material blackPieceMaterial;
    public Material selectedWhitePieceMaterial;
    public Material selectedBlackPieceMaterial;
    private GameObject[] legalMoves;
    private GameObject selectedPiece;

    // Start is called before the first frame update
    public void Start()
    {
        detectMouse = FindObjectOfType<DetectMouse>();
        sceneManager = FindObjectOfType<SceneManager>();
        calculateLegalMoves = FindObjectOfType<CalculateLegalMoves>();

        //Get all the white and black pieces and add them to the pieces array
        var whitePieces = GameObject.FindGameObjectsWithTag("WhitePieces");
        var blackPieces = GameObject.FindGameObjectsWithTag("BlackPieces");
        pieces = new GameObject[whitePieces.Length + blackPieces.Length];
        Array.Copy(whitePieces, pieces, whitePieces.Length);
        Array.Copy(blackPieces, 0, pieces, whitePieces.Length, blackPieces.Length);
    }

    // Update is called once per frame
    public void Update()
    {
        //Check selected unit
        if (detectMouse.clickDetectedOn == null)
        {
            return;
        }        

        if (!detectMouse.clickDetectedOn.gameObject.name.Contains("Square") && 
            detectMouse.clickDetectedOn.gameObject.name != "Board" &&
            detectMouse.clickDetectedOn.gameObject.tag.Contains(sceneManager.PlayerColour.ToString()))
        {
            //Assign the appropriate "selected" material to the selected piece
            detectMouse.clickDetectedOn.gameObject.GetComponent<MeshRenderer>().material = GetCorrectMaterial(detectMouse.clickDetectedOn.gameObject, true);            

            if (selectedPiece != detectMouse.clickDetectedOn.gameObject || legalMoves == null)
            {
                legalMoves = calculateLegalMoves.GetLegalMoves(detectMouse.clickDetectedOn.gameObject);
            }

            //Assign the "regular" unit material to all other pieces
            foreach (var unit in pieces)
            {
                if (unit.gameObject == detectMouse.clickDetectedOn.gameObject)
                {
                    continue;
                }

                unit.gameObject.GetComponent<MeshRenderer>().material = GetCorrectMaterial(unit.gameObject, false);

            }

            //Set the selected piece for comparison on next update
            selectedPiece = detectMouse.clickDetectedOn.gameObject;
        }
        else
        {
            //A square or the board has been clicked so assign the "regular" unit material to all pieces
            foreach (var unit in pieces)
            {
                unit.gameObject.GetComponent<MeshRenderer>().material = GetCorrectMaterial(unit.gameObject, false);                
            }
        }

    }

    private Material GetCorrectMaterial(GameObject gameObject, bool selected)
    {
        var colour = gameObject.tag.Contains("White") ? "white" : "black";

        if (colour == "white")
        { 
            return selected ? selectedWhitePieceMaterial : whitePieceMaterial; 
        }
        else
        {
            return selected ? selectedBlackPieceMaterial : blackPieceMaterial;
        }
    }
}