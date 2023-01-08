using System.Collections;
using System.Net;
using Unity.Networking.Transport;
using UnityEngine;
using TMPro;
using System;

public class ConnectSceneManager : MonoBehaviour
{
    //Server
    public Server server;
    private ushort port = 8007;

    // UI
    [SerializeField] TMP_Text IPAddressText;

    private void Start()
    {
        IPAddressText.text = getIp() + ":" + port;
        server.Init(port);

        RegisterEvents();
    }

    private string getIp()
    {
        IPHostEntry host;
        string localIP = "?";
        host = Dns.GetHostEntry(Dns.GetHostName());

        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localIP = ip.ToString();
            }
        }

        return localIP;
    }

    #region 
    private void RegisterEvents()
    {
        NetUtility.S_WELCOME += OnWelcomeServer;
        NetUtility.S_PING += OnPing;
    }
    private void UnRegisterEvents()
    {
        NetUtility.S_WELCOME -= OnWelcomeServer;
        NetUtility.S_PING -= OnPing;
    }

    // Server
    private void OnPing(NetworkMessage msg, NetworkConnection cnn)
    {
        Debug.Log("hello ping");
        // NetPing netWelcome = msg as NetPing;
    }
    private void OnWelcomeServer(NetworkMessage msg, NetworkConnection cnn)
    {
        Debug.Log("new connector : " + cnn.InternalId);
        NetWelcome netWelcome = msg as NetWelcome;
        Server.Instance.SendToClient(cnn, netWelcome);
    }
    #endregion
}
