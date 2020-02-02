using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Transports.UNET;

public class NetworkGUIManager : MonoBehaviour
{
    public InputField hostAddress;
    public Button joinButton;
    public Button hostButton;
    public Camera menuCamera;

    void Start()
    {
        joinButton.onClick.AddListener(joinServer);
        hostButton.onClick.AddListener(hostServer);
    }

    void Update()
    {

    }

    void joinServer()
    {
        NetworkingManager.Singleton.GetComponent<UnetTransport>().ConnectAddress =
            hostAddress.text;
        NetworkingManager.Singleton.StartClient();
        menuCamera.enabled = false;
        this.gameObject.active = false;
    }

    void hostServer()
    {
        NetworkingManager.Singleton.StartHost();
        menuCamera.enabled = false;
        this.gameObject.active = false;
    }
}


//using MLAPI;
//using MLAPI.Data;
//using MLAPI.MonoBehaviours.Core;
//using System.Net;
//using UnityEngine;

//public class NetManagerHud : MonoBehaviour
//{

//    private void OnGUI()
//    {
//        if (GUI.Button(new Rect(20, 20, 100, 20), "Start client"))
//        {
//            NetworkingManager.singleton.StartClient();
//        }

//        if (GUI.Button(new Rect(20, 70, 100, 20), "Start server"))
//        {
//            NetworkingManager.singleton.StartServer();
//        }

//        if (GUI.Button(new Rect(20, 120, 100, 20), "Start host"))
//        {
//            NetworkingManager.singleton.StartHost();
//        }
//    }
//}