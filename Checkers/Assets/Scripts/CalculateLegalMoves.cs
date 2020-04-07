using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateLegalMoves : MonoBehaviour
{
    public GameObject[] legalMoves;

    public GameObject[] GetLegalMoves(GameObject piece)
    {
        var legalSquareList = new List<GameObject>();
        var legalMoveList = new Dictionary<GameObject, List<GameObject>>();

        //Calculate details about the piece and where it is located
        var squareName = piece.transform.parent.gameObject.name;
        var columnName = piece.transform.parent.gameObject.transform.parent.name;
        var colour = piece.transform.tag == "WhitePieces" ? "White" : "Black";
        var squareNumber = int.Parse(squareName.Split('_')[1]);
        var columnNumber = int.Parse(columnName.Split('_')[1]);

        //Calculate all single square moves
        var leftColumn = GameObject.Find($"Column_{columnNumber-1}");
        var rightColumn = GameObject.Find($"Column_{columnNumber + 1}");

        if (leftColumn != null)
        {            
            var childCount = leftColumn.gameObject.transform.childCount;
            GameObject[] squares = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                squares[i] = leftColumn.gameObject.transform.GetChild(i).gameObject;
            }

            if (squareNumber + 1 > 7 || squareNumber + 1 < 0)
            {
                //out of bounds
            }
            else
            {
                var upperMove = squares[squareNumber + 1];
                legalSquareList.Add(upperMove);
            }

            if (squareNumber -1 >7 || squareNumber -1 <0)
            {
                // out of bounds
            }
            else
            {
                var lowerMove = squares[squareNumber - 1];
                legalSquareList.Add(lowerMove);
            }

            legalMoveList.Add(leftColumn, legalSquareList);
        }

        legalSquareList.RemoveAll(a => a);

        if (rightColumn != null)
        {
            var childCount = rightColumn.gameObject.transform.childCount;
            GameObject[] squares = new GameObject[childCount];

            for (int i = 0; i < childCount; i++)
            {
                squares[i] = rightColumn.gameObject.transform.GetChild(i).gameObject;
            }

            if (squareNumber + 1 > 7 || squareNumber + 1 < 0)
            {
                //out of bounds
            }
            else
            {
                var upperMove = squares[squareNumber + 1];
                legalSquareList.Add(upperMove);
            }

            if (squareNumber - 1 > 7 || squareNumber - 1 < 0)
            {
                // out of bounds
            }
            else
            {
                var lowerMove = squares[squareNumber - 1];
                legalSquareList.Add(lowerMove);
            }

            legalMoveList.Add(rightColumn, legalSquareList);
        }

        string output = string.Empty;

        foreach (var move in legalMoveList)
        {           

            foreach (var square in move.Value)
            {                
                output += $"{square.transform.gameObject.name}, {move.Key.gameObject.name} |";
            }
        }

        output = output.TrimEnd('|');

        Debug.Log("The detected legal moves are: " + output);

        return new GameObject[] { };
    }
}
