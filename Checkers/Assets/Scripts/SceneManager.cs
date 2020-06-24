using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public Colours PlayerColour;
    public bool DebugMode;
    public int whiteStartCol;
    public int blackStartCol;
    private bool foundColZeroFlag = false;
    public Colours WhoseTurnIsIt;

    // Start is called before the first frame update
    void Start()
    {
        //Get the starting columns for each colour
        GetStartingColumnIndexes();

        //Set whose turn it is initially
        WhoseTurnIsIt = Colours.White;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Toggle the turn to the other colour
    /// </summary>
    public Colours ChangeWhoseTurnItIs()
    {
        if (WhoseTurnIsIt == Colours.White)
        {
            WhoseTurnIsIt = Colours.Black;
        }
        else
        {
            WhoseTurnIsIt = Colours.White;
        }

        if (DebugMode)
        {
            Debug.Log($"It is now {WhoseTurnIsIt}'s turn");
        }

        return WhoseTurnIsIt;
    }

    /// <summary>
    /// Gets the initial column indexes for both colours
    /// </summary>
    private void GetStartingColumnIndexes()
    {
        var whitePieces = GameObject.FindGameObjectsWithTag("WhitePieces");

        foreach (var piece in whitePieces)
        {
            var sq = piece.transform.parent.gameObject;

            if (sq.name.Equals("Square_0"))
            {
                foundColZeroFlag = true;
                whiteStartCol = 0;
                blackStartCol = 7;
            }
        }

        if (!foundColZeroFlag)
        {
            blackStartCol = 0;
            whiteStartCol = 7;
        }
    }

    public enum Colours
    {
        Black,White
    }
}
