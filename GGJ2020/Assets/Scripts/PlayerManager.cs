using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;


public class PlayerManager : NetworkedBehaviour
{
    public GameObject camera;
    public delegate void OnHealthChangeDelegate(int health);
    public event OnHealthChangeDelegate OnHealthChange;

    public delegate void OnStateChangeDelegate(playerState state);
    public event OnStateChangeDelegate OnStateChange;

    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float turnSpeed = 2f;
    private int _health = 100;
    private playerState _currentState = playerState.IS_IDLE;
    public int health
    {
        get { return _health; }
        set
        {
            if (_health == value) return;
            _health = value;
            if (OnHealthChange != null)
                OnHealthChange(_health);
        }
    }
    [SerializeField] private int maxHealth = 100;
    
    private Rigidbody rb;
    private PlayerInputActions controls = null;
    private Vector2 moveInput;

    public playerState currentState
    {
        get { return _currentState; }
        set
        {
            if (_currentState == value) return;
            _currentState = value;
            if (OnStateChange != null)
                OnStateChange(_currentState);
        }
    }
    public enum playerState
    {
        IS_IDLE,
        IS_READY,
        IS_DEAD,
        IS_ATTACKING
    }

    private void Start()
    {
        if (this.isLocalPlayer)
        {
            camera.active = true;
        }
        rb = this.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        moveInput = controls.PlayerActions.Move.ReadValue<Vector2>();

        if (Input.GetKeyDown(KeyCode.X))
        {
            takeDamage(1);
        }
    }

    private void FixedUpdate()
    {
        Move(moveInput);
    }

    public void takeDamage(int damage)
    {
        if (health - damage <= 0)
        {
            health = 0;
            killPlayer();
        }
        else
        {
            health -= damage;
        }
    }

    public void healPlayer(int heal)
    {
        if (health + heal > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += heal;
        }
    }

    private void killPlayer()
    {
        currentState = playerState.IS_DEAD;
    }
    
    private void Move(Vector2 moveInput)
    {
        rb.AddForce(transform.forward * moveInput.y * movementSpeed);
        transform.Rotate(new Vector3 { y = moveInput.x * turnSpeed });
    }

    #region HOUSEKEEPING
    private void Awake()
    {
        // Disable the camera
        camera.active = false;

        controls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        controls.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        controls.PlayerActions.Disable();
    }
    #endregion
}
