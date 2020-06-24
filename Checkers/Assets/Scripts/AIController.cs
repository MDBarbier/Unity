using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private SceneManager sceneManager;    
    private CalculateLegalMoves calculateLegalMoves;
    private MovePiece movePiece;
    private bool moveTaken;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        calculateLegalMoves = FindObjectOfType<CalculateLegalMoves>();
        movePiece = FindObjectOfType<MovePiece>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if it's the CPUs turn
        if (sceneManager.WhoseTurnIsIt != sceneManager.PlayerColour)
        {            
            if (sceneManager.DebugMode)
            {
                Debug.Log("CPU turn");
            }

            moveTaken = false;

            //Get list of owned pieces
            GameObject[] ownedPieces;

            if (sceneManager.PlayerColour == SceneManager.Colours.Black)
            {
                ownedPieces = GameObject.FindGameObjectsWithTag("WhitePieces");

                if (sceneManager.DebugMode)
                {
                    Debug.Log("CPU playing white");
                }
            }
            else
            {
                ownedPieces = GameObject.FindGameObjectsWithTag("BlackPieces");

                if (sceneManager.DebugMode)
                {
                    Debug.Log("CPU playing black");
                }
            }

            //Calculate moves for each piece
            foreach (var ownedPiece in ownedPieces)
            {
                (var tempMoves, var possibleCaptures) = calculateLegalMoves.GetLegalMoves(ownedPiece);

                if (possibleCaptures.Count > 0)
                {
                    if (sceneManager.DebugMode)
                    {
                        Debug.Log($"CPU detected possible capture for piece {ownedPiece.name}");
                    }

                    //TODO capture piece

                    moveTaken = true;

                    break;
                }
                else if (tempMoves.Count > 0)
                {
                    if (sceneManager.DebugMode)
                    {
                        Debug.Log($"CPU taking first available move for piece {ownedPiece.name}");
                    }

                    var firstMoveSquare = tempMoves.First().Value.First();

                    movePiece.HandleAIMove(firstMoveSquare, ownedPiece);
                    moveTaken = true;
                    break; 
                }
                else
                {
                    //the current piece has no available moves
                    continue;
                }
            }

            if (!moveTaken)
            {
                Debug.LogError("Could not find a legal move");                
            }
        }
    }
}
