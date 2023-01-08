using System;
using Unity.Networking.Transport;
using UnityEngine;

public enum OpCode // make this enum in other file.
{
    KEEP_ALIVE = 1,
    WELCOME = 2,
    START_GAME = 3,
    MAKE_MOVE = 4,
    REMATCH = 5,
    PING = 6,
}

public static class NetUtility
{
    public static void OnData(DataStreamReader stream, NetworkConnection cnn, Server server = null)
    {
        NetworkMessage msg = null;
        var opCode = (OpCode)stream.ReadByte();
        switch(opCode)
        {
            case OpCode.KEEP_ALIVE: msg = new NetKeepAlive(stream); break;
            case OpCode.PING: msg = new NetPing(stream); break;
            case OpCode.WELCOME: msg = new NetWelcome(stream); break;
            // case OpCode.START_GAME: msg = new NetStartGame(stream); break;
            // case OpCode.MAKE_MOVE: msg = new NetMakeMove(stream); break;
            // case OpCode.REMATCH: msg = new NetRematch(stream); break;
            default:
                Debug.LogError("Message received had no OpCode");
                break;
        }

        if(server != null)
        {
            msg.ReceivedOnServer(cnn);
        }
        else
        {
            msg.ReceivedOnClient();
        }
    }

    // Network message (action)
    public static Action<NetworkMessage> C_KEEP_ALIVE;
    public static Action<NetworkMessage> C_WELCOME;
    public static Action<NetworkMessage> C_START_GAME;
    public static Action<NetworkMessage> C_MAKE_MOVE;
    public static Action<NetworkMessage> C_REMATCH;
    public static Action<NetworkMessage> C_PING;
    public static Action<NetworkMessage, NetworkConnection> S_KEEP_ALIVE;
    public static Action<NetworkMessage, NetworkConnection> S_WELCOME;
    public static Action<NetworkMessage, NetworkConnection> S_START_GAME;
    public static Action<NetworkMessage, NetworkConnection> S_MAKE_MOVE;
    public static Action<NetworkMessage, NetworkConnection> S_REMATCH;
    public static Action<NetworkMessage, NetworkConnection> S_PING;
}
