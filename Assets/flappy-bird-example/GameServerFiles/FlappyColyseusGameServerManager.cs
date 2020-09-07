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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // game3.js: override this on your class
    public override bool ConnectToGameServer()
    {
        Debug.Log("Connecting!");

        return true;
    }
}
