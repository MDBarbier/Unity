using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    public void Start()
    { 
    
    }

    public void Update()
    { 
        //TODO - Logic to move pieces

        //Catch clicks that are on squares

        //Is there a selected piece (i.e. does any piece have the "selected" material on it's mesh renderer?

        //If there is a selected piece get it's legal moves

        //Is the square that was clicked on one of the legal moves?

        //If yes, move the piece to the square, and remove any pieces in the capture list

        //If a piece was captured, retain the turn on the current player and check legal moves again
    }


    public void MovePieceToSpecifiedSquare(GameObject pieceToMove, GameObject destinationSquare)
    {
        pieceToMove.transform.SetParent(destinationSquare.transform);
    }
}
