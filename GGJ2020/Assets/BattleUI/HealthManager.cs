using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private PlayerManager _player;
    [SerializeField] private int maxWidth = 425;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerManager>();
        _player.OnHealthChange += UpdateHealthBar;

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth, 45);

    }

    void UpdateHealthBar(int health)
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2((maxWidth / 100) * health, 45);
    }
}
