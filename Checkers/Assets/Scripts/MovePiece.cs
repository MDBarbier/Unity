﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    private DetectMouse detectMouse;
    private SelectPiece selectPiece;
    private SceneManager sceneManager;
    private CalculateLegalMoves calculateLegalMoves;
    private CapturePiece capturePiece;

    public void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        detectMouse = FindObjectOfType<DetectMouse>();
        selectPiece = FindObjectOfType<SelectPiece>();
        calculateLegalMoves = FindObjectOfType<CalculateLegalMoves>();
        capturePiece = FindObjectOfType<CapturePiece>();
    }

    public void Update()
    {
        if (!detectMouse.leftMouseClick)
            return;

        //Catch clicks that are on squares        
        if (detectMouse != null && detectMouse.clickDetectedOn != null && detectMouse.clickDetectedOn.tag == "Square")
        {
            if (sceneManager.DebugMode)
                Debug.Log("Empty square clicked");

            //Is there a selected piece currently (i.e. does any piece have the "selected" material on it's mesh renderer?
            if (selectPiece.selectedPiece != null)
            {
                //If there is a selected piece get it's legal moves
                (var legalMoves, var capturedPieces) = calculateLegalMoves.GetLegalMoves(selectPiece.selectedPiece);

                //Get the go representing the column that current square is in
                var columnGo = detectMouse.clickDetectedOn.transform.parent.gameObject;

                //If the column is in the list of legal moves, get the squares of that column that are legal moves
                var matchingSquares = legalMoves.Where(a => a.Key.name == columnGo.name).Select(a => a.Value).FirstOrDefault();

                //Do any of the squares corresponsd to the square that was clicked on?
                var destinationSquare = matchingSquares?.Where(a => a.name == detectMouse.clickDetectedOn.name).FirstOrDefault();

                //If we have a match, move the selected piece to that square
                if (destinationSquare != null)
                {
                    MovePieceToSpecifiedSquare(selectPiece.selectedPiece, destinationSquare);
                }

                //Were any pieces captured as a result of this move?
                foreach (var capturedPiece in capturedPieces)
                {                    
                    //compare the starting square to the destination square and column
                    var startColumn = selectPiece.selectedPiece.transform.parent.gameObject.transform.parent.gameObject;
                    var startSquare = selectPiece.selectedPiece.transform.parent.gameObject;

                    //get the location of the potential capture
                    var captureColumn = capturedPiece.transform.parent.gameObject.transform.parent.gameObject;
                    var captureSquare = capturedPiece.transform.parent.gameObject;

                    //get all the indexes
                    var startColIndex = int.Parse(startColumn.name.Split('_')[1]);
                    var startSquareIndex = int.Parse(startSquare.name.Split('_')[1]);
                    var destColIndex = int.Parse(columnGo.name.Split('_')[1]);
                    var destSqaureIndex = int.Parse(destinationSquare.name.Split('_')[1]);
                    var captureSquareIndex = int.Parse(captureSquare.name.Split('_')[1]);
                    var captureColumnIndex = int.Parse(captureColumn.name.Split('_')[1]);

                    //TODO debug this shit
                    //Is the index of the capture col betwixt that of the starting col and destination col?
                    if ((captureColumnIndex > destColIndex && captureColumnIndex < startColIndex) || (captureColumnIndex < destColIndex && captureColumnIndex > startColIndex))
                    {
                        //Is the index of the capture square betwixt that of the starting square and destination square?
                        if ((captureSquareIndex > destSqaureIndex && captureSquareIndex < startSquareIndex) || (captureSquareIndex > destSqaureIndex && captureSquareIndex > startSquareIndex))
                        {
                            capturePiece.CaptureSpecifiedPiece(capturedPiece);
                        }
                    }                    
                }

                //Set all squares that are not legal moves for the currently selected piece back to their proper material
                foreach (var storedMaterial in new Dictionary<(int, int), (Material, GameObject)>(selectPiece.storedSquareColours))
                {
                    //Get the squares game object for this iteration
                    var storedColumnGo = GameObject.Find("Column_" + storedMaterial.Key.Item1);
                    var storedSquareGo = storedColumnGo.transform.Find("Square_" + storedMaterial.Key.Item2).gameObject;
                    storedSquareGo.GetComponent<MeshRenderer>().material = storedMaterial.Value.Item1;
                    selectPiece.storedSquareColours.Remove(storedMaterial.Key);
                }

                //get new legal moves
                legalMoves = calculateLegalMoves.GetLegalMoves(selectPiece.selectedPiece).Item1;

                //highlight new available moves
                foreach (var column in legalMoves)
                {
                    foreach (var square in column.Value)
                    {
                        var columnIndex = int.Parse(column.Key.name.Split('_')[1]);
                        var squareIndex = int.Parse(square.name.Split('_')[1]);

                        if (!selectPiece.storedSquareColours.ContainsKey((columnIndex, squareIndex)))
                        {
                            selectPiece.storedSquareColours.Add((columnIndex, squareIndex), (square.gameObject.GetComponent<MeshRenderer>().material, detectMouse.clickDetectedOn.gameObject));
                        }

                        square.gameObject.GetComponent<MeshRenderer>().material = selectPiece.highlightedSquare;
                    }
                }
            }
        }
    }


    /// <summary>
    /// Move a piece to another square
    /// </summary>
    /// <param name="pieceToMove">The game object of the piece to move</param>
    /// <param name="destinationSquare">The game object of the square to move the piece to</param>
    public void MovePieceToSpecifiedSquare(GameObject pieceToMove, GameObject destinationSquare)
    {
        pieceToMove.transform.SetParent(destinationSquare.transform);
        pieceToMove.transform.localPosition = new Vector3(0, 0.5f);
    }
}
