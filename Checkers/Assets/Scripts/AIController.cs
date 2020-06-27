using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;

public class AIController : MonoBehaviour
{
    private SceneManager sceneManager;
    private CalculateLegalMoves calculateLegalMoves;
    private MovePiece movePiece;
    private CapturePiece capturePiece;
    private bool moveTaken;
    private BannerController bannerController;
    private int updateCountdown;

    [SerializeField]
    public int framesDelay;

    // Start is called before the first frame update
    void Start()
    {
        updateCountdown = framesDelay;
        bannerController = FindObjectOfType<BannerController>();
        sceneManager = FindObjectOfType<SceneManager>();
        calculateLegalMoves = FindObjectOfType<CalculateLegalMoves>();
        movePiece = FindObjectOfType<MovePiece>();
        capturePiece = FindObjectOfType<CapturePiece>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if it's the CPUs turn
        if (sceneManager.WhoseTurnIsIt != sceneManager.PlayerColour)
        {
            if (updateCountdown <= 0)
            {
                if (sceneManager.DebugMode)
                {
                    Debug.Log("CPU turn");
                }

                bannerController.SetBannerMessage("CPU turn");


                HandleMove();

                updateCountdown = framesDelay;
            }
            else
            {
                updateCountdown--;
            }
        }       
    }

    private void HandleMove()
    {
        moveTaken = false;
        //Get list of owned pieces
        GameObject[] ownedPieces;

        if (sceneManager.PlayerColour == SceneManager.Colours.Black)
        {
            ownedPieces = GameObject.FindGameObjectsWithTag("WhitePieces").Where(a => a.activeSelf).ToArray();

            if (sceneManager.DebugMode)
            {
                Debug.Log("CPU playing white");
            }
        }
        else
        {
            ownedPieces = GameObject.FindGameObjectsWithTag("BlackPieces").Where(a => a.activeSelf).ToArray();

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

                //work out which move it is for the first capture
                var captureToTake = possibleCaptures.First();

                var squareOfPieceToCapture = captureToTake.transform.parent.gameObject;
                var columnOfPieceToCapture = squareOfPieceToCapture.transform.parent.gameObject;

                var columnIndexOfCapturedPiece = int.Parse(columnOfPieceToCapture.name.Split('_')[1]);
                var squareIndexOfCapturedPiece = int.Parse(squareOfPieceToCapture.name.Split('_')[1]);
                var squareIndexOfStartingSpace = int.Parse(ownedPiece.transform.parent.gameObject.name.Split('_')[1]);
                var columnIndexOfStartingSpace = int.Parse(ownedPiece.transform.parent.transform.parent.transform.gameObject.name.Split('_')[1]);
                int columnIndexOfSpaceToMoveTo;
                int squareIndexOfSpaceToMoveTo;

                if (columnIndexOfCapturedPiece > columnIndexOfStartingSpace)
                {
                    columnIndexOfSpaceToMoveTo = columnIndexOfCapturedPiece + 1;
                }
                else
                {
                    columnIndexOfSpaceToMoveTo = columnIndexOfCapturedPiece - 1;
                }

                if (sceneManager.blackStartCol == 0)
                {
                    squareIndexOfSpaceToMoveTo = squareIndexOfCapturedPiece + 1;
                }
                else
                {
                    squareIndexOfSpaceToMoveTo = squareIndexOfCapturedPiece - 1;
                }

                //move piece
                var squareToMoveTo = tempMoves.Where(a => a.Key.name == $"Column_{columnIndexOfSpaceToMoveTo}").Single().Value.Where(a => a.name == $"Square_{squareIndexOfSpaceToMoveTo}").Single();
                movePiece.HandleAIMove(squareToMoveTo, ownedPiece);

                //capture piece
                capturePiece.CaptureSpecifiedPiece(captureToTake);

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
