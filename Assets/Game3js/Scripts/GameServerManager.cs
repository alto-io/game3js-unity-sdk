using UnityEngine;

public abstract class GameServerManager : MonoBehaviour
{
    public abstract void ConnectToGameServer(string endpoint);
}
