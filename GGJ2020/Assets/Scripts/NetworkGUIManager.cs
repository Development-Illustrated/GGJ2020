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

    public BuilderController builderController;

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
        this.gameObject.SetActive(false);
    }

    void hostServer()
    {
        NetworkingManager.Singleton.StartHost();
        menuCamera.enabled = false;
        this.gameObject.SetActive(false);
    }
}