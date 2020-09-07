using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Game3jsManager : SceneSingleton<Game3jsManager>
{
    public UnityGameStateManager gameManager; // game3.js : your game state manager should derive from UnityGameStateManager
    public GameServerManager gameServerManager; // game3.js : a game server for more secure authoritative game results

    public bool showDebugControls;

    public Canvas debugControlCanvas;

    public GameObject logScrollViewContent;
    public Text game3jsStateText;
    public InputField serverUrlInputField;

    public InputField messageInputField;
    public InputField levelInputField;
    public InputField timeInputField;


    struct Game3jsEvents
    {
        public const string GameReady = "GameReady";
        public const string GameEndFail = "GameEndFail";
        public const string GameEndSuccess = "GameEndSuccess";
        public const string WaitingForGameServer = "WaitingForGameServer";
        public const string GameRunning = "GameRunning";

    }

    [DllImport("__Internal")]
    private static extern void SendString(string message);

    [DllImport("__Internal")]
    private static extern void SendEvent(string message);


    // Start is called before the first frame update
    IEnumerator Start()
    {

        while (!SplashScreen.isFinished)
        {
            yield return null;
        }
        Debug.Log("Finished showing splash screen");

        this.debugControlCanvas.enabled = showDebugControls;

        // disable key input to allow login / register functionality
#if UNITY_WEBGL
        try
        {
            WebGLInput.captureAllKeyboardInput = false;
        } catch (System.Exception e)
        {
            
        }
#endif

        if (gameServerManager == null)
        {
            SignalGameReady();
        }
        else
        {
            game3jsStateText.text = Game3jsEvents.WaitingForGameServer;
            game3jsStateText.color = Color.cyan;
            SendEvent(Game3jsEvents.WaitingForGameServer);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConsoleLog(string message, Color messageColor)
    {
        Debug.Log(message);
        DefaultControls.Resources r = new DefaultControls.Resources();
        GameObject NewText = DefaultControls.CreateText(r);
        NewText.AddComponent<LayoutElement>();
        NewText.GetComponent<Text>().text = message;
        NewText.GetComponent<Text>().color = messageColor;
        NewText.transform.SetParent(logScrollViewContent.transform);
    }

    public void ClickSendMessageButton()
    {
        SendString(messageInputField.text);
    }

    public void SignalGameReady()
    {
        game3jsStateText.text = Game3jsEvents.GameReady;
        game3jsStateText.color = Color.yellow;
        SendEvent(Game3jsEvents.GameReady);
    }

    public void StartGame(string message)
    {
        // game3.js: 
        // Add a StartGame3js method in your Game Manager class that begins the game.

        if (game3jsStateText.text == Game3jsEvents.GameReady)
        {
            game3jsStateText.text = Game3jsEvents.GameRunning;
            game3jsStateText.color = Color.green;
            gameManager.StartGame3js();
        }
    }

    public void GameEndFail()
    {
        game3jsStateText.text = Game3jsEvents.GameEndFail;
        game3jsStateText.color = Color.red;


        // inform JS that we've finished the game
        SendEvent(Game3jsEvents.GameEndFail);

     
    }

    public void GameEndSuccess()
    {
        game3jsStateText.text = Game3jsEvents.GameEndSuccess;
        game3jsStateText.color = Color.red;

        // inform JS that we've finished the game
        SendEvent(Game3jsEvents.GameEndSuccess);

    }

    public void ConnectToServer(string url)
    {
        string endpoint = serverUrlInputField.text;

        if (url != "")
        {
            endpoint = url;
        }

        gameServerManager.ConnectToGameServer(endpoint);
    }

    public void SetTime(double currentTime)
    {
        int ms = (int)((currentTime % 1) * 1000);
        int s = (int)currentTime % 60;
        int m = (int)currentTime / 60;

        timeInputField.text = string.Format("{0:D2}:{1:D2}:{2:D3}", m, s, ms);

    }

    public void SetLevel(string text)
    {
        levelInputField.text = text;
    }

    public string GetLevel()
    {
        return levelInputField.text;
    }
}
