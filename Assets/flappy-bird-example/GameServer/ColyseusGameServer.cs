using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ColyseusGameServer : GameServer
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // game3.js: override this on your class
    public override bool InitializeGameServer()
    {
        Debug.Log("Initializing!");

        return true;
    }
}
