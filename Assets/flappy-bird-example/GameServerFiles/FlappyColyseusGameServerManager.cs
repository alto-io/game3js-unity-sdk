using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using System.Threading;
using System.Threading.Tasks;

using Colyseus;
using Colyseus.Schema;

using GameDevWare.Serialization;

public class FlappyColyseusGameServerManager : GameServerManager
{

    protected Client client;
    protected Room<State> room;


    [Serializable]
    class Metadata
    {
        public string str;
        public int number;
    }

    [Serializable]
    class CustomRoomAvailable : RoomAvailable
    {
        public Metadata metadata;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // game3.js: override this on your class
    public override async void ConnectToGameServer(string endpoint)
    {
        Game3jsManager.Instance.ConsoleLog("Connecting to " + endpoint, Color.black);
        string roomName = "demo";

        client = ColyseusManager.Instance.CreateClient(endpoint);

        CheckConnection();
    }


    async void CheckConnection()
    {
        try
        {
            var roomsAvailable = await client.GetAvailableRooms<CustomRoomAvailable>();
            if (roomsAvailable != null) 
            {
                Game3jsManager.Instance.ConsoleLog("Connection success", Color.cyan);
                Game3jsManager.Instance.SignalGameReady();
            }
        }
        catch (Exception e)
        {
            if (!(e is EntryPointNotFoundException))
            Game3jsManager.Instance.ConsoleLog("Unable to connect", Color.red);
        }
    }

    async void GetAvailableRooms()
    {
        var roomsAvailable = await client.GetAvailableRooms<CustomRoomAvailable>();

        Debug.Log("Available rooms (" + roomsAvailable.Length + ")");
        for (var i = 0; i < roomsAvailable.Length; i++)
        {
            Debug.Log("roomId: " + roomsAvailable[i].roomId);
            Debug.Log("maxClients: " + roomsAvailable[i].maxClients);
            Debug.Log("clients: " + roomsAvailable[i].clients);
            Debug.Log("metadata.str: " + roomsAvailable[i].metadata.str);
            Debug.Log("metadata.number: " + roomsAvailable[i].metadata.number);
        }
    }
}
