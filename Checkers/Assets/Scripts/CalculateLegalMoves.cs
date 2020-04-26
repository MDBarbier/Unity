using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CalculateLegalMoves : MonoBehaviour
{
    public GameObject[] legalMoves;
    private List<GameObject> captureList;
    
    public ValueTuple<Dictionary<GameObject, List<GameObject>>, List<GameObject>> GetLegalMoves(GameObject piece)
    {        
        var legalSquareList = new List<GameObject>();
        var legalMoveList = new Dictionary<GameObject, List<GameObject>>();
        captureList = new List<GameObject>();

        //Calculate details about the piece and where it is located
        var squareName = piece.transform.parent.gameObject.name;
        var columnName = piece.transform.parent.gameObject.transform.parent.name;
        var colour = piece.transform.tag == "WhitePieces" ? "White" : "Black";
        var squareNumber = int.Parse(squareName.Split('_')[1]);
        var columnNumber = int.Parse(columnName.Split('_')[1]);        

        //Calculate all single square moves
        var leftColumn = GameObject.Find($"Column_{columnNumber - 1}");
        var rightColumn = GameObject.Find($"Column_{columnNumber + 1}");

        var leftResults = (ProcessColumn(leftColumn, squareNumber, columnNumber, colour, false));
        var rightResults = ProcessColumn(rightColumn , squareNumber, columnNumber, colour, true);

        leftResults.ToList().ForEach(x => legalMoveList.Add(x.Key, x.Value));
        rightResults.ToList().ForEach(x => legalMoveList.Add(x.Key, x.Value));                

        return (legalMoveList, captureList);
    }

    private Dictionary<GameObject, List<GameObject>> ProcessColumn(GameObject columnToProcess, int squareNumberOfSelectedPiece, int columnNumberOfSelectedPiece, string selectedPieceColour, bool increcmentColumn)
    {
        var legalSquareList = new List<GameObject>();
        var legalMoveList = new Dictionary<GameObject, List<GameObject>>();

        if (columnToProcess != null)
        {
            var childCount = columnToProcess.gameObject.transform.childCount;
            GameObject[] squares = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                squares[i] = columnToProcess.gameObject.transform.Find("Square_" + i.ToString()).gameObject;
            }
            
            if (squareNumberOfSelectedPiece + 1 > 7 || squareNumberOfSelectedPiece + 1 < 0)
            {
                //out of bounds
            }
            else
            {
                var upperMove = squares[squareNumberOfSelectedPiece + 1];
                
                ProcessSquare(
                    ref legalMoveList,
                    upperMove,
                    ref legalSquareList,
                    selectedPieceColour,
                    columnNumberOfSelectedPiece,
                    squareNumberOfSelectedPiece,
                    increcmentColumn,
                    columnToProcess,
                    squares,
                    childCount,
                    true);
               
            }

            if (squareNumberOfSelectedPiece - 1 > 7 || squareNumberOfSelectedPiece - 1 < 0)
            {
                // out of bounds
            }
            else
            {
                var lowerMove = squares[squareNumberOfSelectedPiece - 1];

                ProcessSquare(
                    ref legalMoveList, 
                    lowerMove, 
                    ref legalSquareList, 
                    selectedPieceColour, 
                    columnNumberOfSelectedPiece, 
                    squareNumberOfSelectedPiece, 
                    increcmentColumn, 
                    columnToProcess, 
                    squares, 
                    childCount,
                    false);                
            }

            if (legalSquareList.Count > 0)
            {
                legalMoveList.Add(columnToProcess, new List<GameObject>(legalSquareList));
            }
        }

        return legalMoveList;
    }

    private void ProcessSquare(
        ref Dictionary<GameObject, List<GameObject>> legalMoveList, 
        GameObject moveToProcess, 
        ref List<GameObject> legalSquareList, 
        string selectedPieceColour, 
        int columnNumberOfSelectedPiece, 
        int squareNumberOfSelectedPiece, 
        bool increcmentColumn, 
        GameObject columnToProcess, 
        GameObject[] squares, 
        int childCount,
        bool incrementSquare)
    {
        //Check whether the square is occupied
        if (moveToProcess.gameObject.transform.childCount > 0)
        {
            //Check whether capture can occur
            var pieceInSquare = moveToProcess.gameObject.transform.GetChild(0);

            if (!pieceInSquare.gameObject.tag.Contains(selectedPieceColour))
            {
                //Check whether the space beyond the opposing piece is free
                var beyondColIndex = increcmentColumn ? columnNumberOfSelectedPiece + 2 : columnNumberOfSelectedPiece - 2;
                var beyondchildCount = GameObject.Find("Column_" + beyondColIndex).transform.childCount;
                GameObject[] beyondSquares = new GameObject[beyondchildCount];
                for (int i = 0; i < childCount; i++)
                {
                    squares[i] = GameObject.Find("Column_" + beyondColIndex).transform.Find("Square_" + i.ToString()).gameObject;
                }
                var beyondMove = incrementSquare ? squares[squareNumberOfSelectedPiece + 2] : squares[squareNumberOfSelectedPiece - 2];
                if (beyondMove.gameObject.transform.childCount == 0)
                {
                    //Space is free, capture can occur
                    Debug.Log($"Piece in {moveToProcess.name}, {columnToProcess.name} would be captured!");

                    captureList.Add(pieceInSquare.gameObject);
                                        
                    var beyondLegalSquareList = new List<GameObject>();
                    beyondLegalSquareList.Add(beyondMove);
                    legalMoveList.Add(GameObject.Find("Column_" + beyondColIndex), beyondLegalSquareList);
                }
            }
        }
        else
        {
            legalSquareList.Add(moveToProcess);
        }
    }
}
