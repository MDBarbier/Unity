using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    #region Gamestate

    private int level;
    GameState gameState = GameState.Menu;
    private string easyPassword = "buffy";
    private string mediumPassword = "batmobile";
    private string hardPassword = "maytheforcebewithyou";
    #endregion

    #region Unit message handlers

    // Start is called before the first frame update
    void Start()
    {
        var greeting = "Hello hacker";
        DisplayMainMenu(greeting);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Other message handlers
    //This is not a unity method, it's defined within the WM2000 module
    void OnUserInput(string input)
    {
        switch (gameState)
        {
            case GameState.Menu:
                HandleInputOnMainMenu(input);
                break;
            case GameState.Game:
                HandleInputOnGame(input);
                break;
            case GameState.Win:
                HandleInputOnWin();
                break;
            default:
                break;
        }
    }

    #endregion

    #region Methods

    private void HandleInputOnWin()
    {
        gameState = GameState.Menu;
        DisplayMainMenu("Welcome 1337 hacker");
    }

    private void HandleInputOnGame(string input)
    {
        bool success = CheckPassword(input);        

        if (success)
        {
            gameState = GameState.Win;
            WinGame();            
        }
        else
        {
            Terminal.WriteLine("Incorrect password entered! Try again: ");
        }
        
    }

    private bool CheckPassword(string input)
    {
        switch (level)
        {
            case 1:
                return (input == easyPassword) ? true : false;                
            case 2:
                return (input == mediumPassword) ? true : false;
            case 3:
                return (input == hardPassword) ? true : false;
            default:
                throw new Exception("CheckPassword error: no such level as " + level);                
        }
    }

    private void HandleInputOnMainMenu(string input)
    {
        switch (input)
        {
            case "menu":
                DisplayMainMenu("Hello hacker");
                break;
            case "1":
            case "2":
            case "3":
                level = int.Parse(input);
                StartGame();
                break;
            case "exit":
                ExitGame();
                break;
            default:                
                DisplayMainMenu($"Option {input} was not found!");
                break;
        }
    }

    private void ExitGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("You are logged out");
        Terminal.WriteLine("Press enter to log back in");
        gameState = GameState.Menu;
        print("Calling application.Quit (will be ignored when running in Unity editor!");
        Application.Quit();
    }

    private void WinGame()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Password entry successful....");
        Terminal.WriteLine("Copying files to local machine...");
        Terminal.WriteLine("Deleting log entries...");
        Terminal.WriteLine("Disconnecting from remote host");
        Terminal.WriteLine(".");
        Terminal.WriteLine(".");
        Terminal.WriteLine(".");
        Terminal.WriteLine(".");
        Terminal.WriteLine(".");
        Terminal.WriteLine("You win, thanks for playing!");
    }

    private void DisplayMainMenu(string greeting)
    {
        gameState = GameState.Menu;

        List<string> mainMenuLines = new List<string>()
        {
            $"{greeting}",
            "initialising secure tcp/ip connection..",
            "...",
            "...",
            "connection established!",
            "",
            "Select the host to hack:",
            "(1) 76.45.123.1",
            "   --DNS entry: Sunnydale high",
            "(2) 69.53.11.3",
            "   --DNS entry: Gotham PD",
            "(3) 58.123.05.1/21",
            "   --(DNS entry: The White House)",
        };

        Terminal.ClearScreen();

        RenderLineList(mainMenuLines);
    }

    private void StartGame()
    {
        Terminal.ClearScreen();
        List<string> levelLines = new List<string>();
        gameState = GameState.Game;

        switch (level)
        {
            case 1:
                levelLines.Add("Connected to 76.45.123.1...");
                levelLines.Add("FQDN: staff.sunnydalehigh.edu");
                levelLines.Add("Hostname: GilesPC");
                levelLines.Add("");
                levelLines.Add("Enter password:");
                break;
            case 2:
                levelLines.Add("Connected to 69.53.11.3...");
                levelLines.Add("FQDN: commissioner.gotham.pd");
                levelLines.Add("Hostname: GordonLaptop");
                levelLines.Add("");
                levelLines.Add("Enter password:");
                break;
            case 3:
                levelLines.Add("Connected to 758.123.05.1/21...");
                levelLines.Add("FQDN: oval.whitehouse.gov");
                levelLines.Add("Hostname: ILoveCheeseburger");
                levelLines.Add("");
                levelLines.Add("Enter password:");
                break;
            default:
                throw new Exception("StartGame error: Level not recognised");
        }

        RenderLineList(levelLines);
    }

    private void RenderLineList(List<string> lines)
    {
        Terminal.ClearScreen();
        foreach (var line in lines)
        {
            Terminal.WriteLine(line);
        }
    }

    #endregion

    #region Objects

    private enum GameState
    {
        Menu, Game, Win
    }

    #endregion
}
