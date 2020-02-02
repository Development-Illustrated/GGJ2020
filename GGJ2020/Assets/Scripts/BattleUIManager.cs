using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MLAPI;
using MLAPI.Transports;

public class BattleUIManager : NetworkedBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject weaponBar;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deadText;
    [SerializeField] private Button restartGame;

    private PlayerManager _player;
    private int healthBarMax = 425;

    // Start is called before the first frame update
    void Start()
    {
        _player = player.GetComponent<PlayerManager>();
        _player.OnHealthChange += UpdateHealthBar;
        _player.OnStateChange += UpdateState;

        deadText.gameObject.SetActive(false);

        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthBarMax, 45);

        restartGame.onClick.AddListener(restartScene);


        // if (NetworkingManager.Singleton.IsHost)
        // {
        //     restartGame.GetComponent<Text>().text = "End Game";
        // }
        // else
        // {
        //     restartGame.GetComponent<Text>().text = "Leave Game";
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateHealthBar(int health) => healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2((healthBarMax / 100) * health, 45);

    void UpdateState(PlayerManager.playerState state)
    {
        if (state == PlayerManager.playerState.IS_DEAD)
        { 
            if (this.IsLocalPlayer)
            {
                deadText.gameObject.SetActive(true);
                weaponBar.gameObject.SetActive(false);
                healthBar.gameObject.SetActive(false);
            } 
        }
    }

    void restartScene()
    {
        if (NetworkingManager.Singleton.IsHost)
        {
            var connectedClients = NetworkingManager.Singleton.ConnectedClientsList;

            foreach(var client in connectedClients)
            {
                NetworkingManager.Singleton.DisconnectClient(client.ClientId);
            }
            
            NetworkingManager.Singleton.StopHost();
        }
        else
        {
            NetworkingManager.Singleton.StopClient();
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
