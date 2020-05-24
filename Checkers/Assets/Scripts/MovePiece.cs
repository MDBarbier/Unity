using System.Linq;
using UnityEngine;

public class MovePiece : MonoBehaviour
{
    private DetectMouse detectMouse;
    private SelectPiece selectPiece;
    private SceneManager sceneManager;
    private CalculateLegalMoves calculateLegalMoves;

    public void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        detectMouse = FindObjectOfType<DetectMouse>();
        selectPiece = FindObjectOfType<SelectPiece>();
        calculateLegalMoves = FindObjectOfType<CalculateLegalMoves>();
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
                var legalMoves = calculateLegalMoves.GetLegalMoves(selectPiece.selectedPiece).Item1;

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

                //TODO Were any pieces captured as a result of this move?

                //TODO If a piece was captured, retain the turn on the current player and check legal moves again

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
