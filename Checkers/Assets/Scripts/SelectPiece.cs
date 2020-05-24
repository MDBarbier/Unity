using System;
using System.Collections.Generic;
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
    public Material highlightedSquare;
    public Material reqSquare;
    public Material whiteSquare;
    private Dictionary<GameObject, List<GameObject>> legalMoves;
    private List<GameObject> captureList;
    public GameObject selectedPiece;    

    //Key is the column and square index, value is value tuple of the original material and the gameobject the legal move applies to
    private Dictionary<ValueTuple<int, int>, ValueTuple<Material, GameObject>> storedSquareColours;

    // Start is called before the first frame update
    public void Start()
    {
        detectMouse = FindObjectOfType<DetectMouse>();
        sceneManager = FindObjectOfType<SceneManager>();
        calculateLegalMoves = FindObjectOfType<CalculateLegalMoves>();
        storedSquareColours = new Dictionary<ValueTuple<int, int>, ValueTuple<Material, GameObject>>();        

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
        if (detectMouse.clickDetectedOn == null || detectMouse.clickDetectedOn.tag == "Square")
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
                (legalMoves, captureList) = calculateLegalMoves.GetLegalMoves(detectMouse.clickDetectedOn.gameObject);

                //highlight available moves
                foreach (var column in legalMoves)
                {
                    foreach (var square in column.Value)
                    {
                        var columnIndex = int.Parse(column.Key.name.Split('_')[1]);
                        var squareIndex = int.Parse(square.name.Split('_')[1]);

                        if (!storedSquareColours.ContainsKey((columnIndex, squareIndex)))
                        {
                            storedSquareColours.Add((columnIndex, squareIndex), (square.gameObject.GetComponent<MeshRenderer>().material, detectMouse.clickDetectedOn.gameObject));
                        }

                        square.gameObject.GetComponent<MeshRenderer>().material = highlightedSquare;
                    }
                }
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

            //Set all squares that are not legal moves for the currently selected piece back to their proper material
            foreach (var storedMaterial in new Dictionary<(int, int), (Material, GameObject)>(storedSquareColours))
            {
                //Is the game object the stored value relates to the selected piece?
                if (storedMaterial.Value.Item2 == selectedPiece)
                {
                    continue;
                }

                //Get the squares game object for this iteration
                var columnGo = GameObject.Find("Column_" + storedMaterial.Key.Item1);
                var squareGo = columnGo.transform.Find("Square_" + storedMaterial.Key.Item2).gameObject;

                //If the legalMoves Dict contains the same square, do not reset it
                var legalMovesMatches = legalMoves.Where(a => a.Key == columnGo && a.Value.Contains(squareGo)).Count();

                if (legalMovesMatches <= 0)
                {
                    squareGo.GetComponent<MeshRenderer>().material = storedMaterial.Value.Item1;
                    storedSquareColours.Remove(storedMaterial.Key);
                }
            }
        }
        else
        {
            //A square or the board has been clicked so assign the "regular" unit material to all pieces
            foreach (var unit in pieces)
            {
                unit.gameObject.GetComponent<MeshRenderer>().material = GetCorrectMaterial(unit.gameObject, false);
            }

            //Set all squares that are not legal moves for the currently selected piece back to their proper material
            foreach (var storedMaterial in new Dictionary<(int, int), (Material, GameObject)>(storedSquareColours))
            {
                //Get the squares game object for this iteration
                var columnGo = GameObject.Find("Column_" + storedMaterial.Key.Item1);
                var squareGo = columnGo.transform.Find("Square_" + storedMaterial.Key.Item2).gameObject;
                squareGo.GetComponent<MeshRenderer>().material = storedMaterial.Value.Item1;
                storedSquareColours.Remove(storedMaterial.Key);
                legalMoves = null;
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