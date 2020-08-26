using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Game3jsManager : SceneSingleton<Game3jsManager>
{
    public ExampleGameManager gameManager; // game3.js : Replace the ExampleGameManager with your equivalent game manager class

    public GameObject logScrollViewContent;
    public GameObject game3jsStateText;

    public InputField messageInputField;
    public InputField levelInputField;
    public InputField timeInputField;

    struct Game3jsEvents
    {
        public const string GameReady = "GameReady";
        public const string GameEndFail = "GameEndFail";
        public const string GameEndSuccess = "GameEndSuccess";

    }

    [DllImport("__Internal")]
    private static extern void SendString(string message);

    [DllImport("__Internal")]
    private static extern void SendEvent(string message);

    // Start is called before the first frame update
    void Start()
    {
        // disable key input to allow login / register functionality
#if UNITY_WEBGL
        try
        {
            WebGLInput.captureAllKeyboardInput = false;
        } catch (System.Exception e)
        {
            
        }
    #endif

        // inform web app that sdk is ready
        SendEvent(Game3jsEvents.GameReady);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConsoleLog(string message)
    {
        Debug.Log(message);
        DefaultControls.Resources r = new DefaultControls.Resources();
        GameObject NewText = DefaultControls.CreateText(r);
        NewText.AddComponent<LayoutElement>();
        NewText.GetComponent<Text>().text = message;
        NewText.GetComponent<Text>().color = Color.red;
        NewText.transform.SetParent(logScrollViewContent.transform);
    }

    public void ClickSendMessageButton()
    {
        SendString(messageInputField.text);
    }

    public void StartGame(string message)
    {
        // game3.js: 
        // Add a StartGame3js method in your Game Manager class that begins the game.

        gameManager.StartGame3js();
    }

    public void GameEndFail()
    {
        // inform JS that we've finished the game
        SendEvent(Game3jsEvents.GameEndFail);
    }

    public void GameEndSuccess()
    {
        // inform JS that we've finished the game
        SendEvent(Game3jsEvents.GameEndSuccess);
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
