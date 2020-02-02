using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MLAPI;

public class PlayerManager : NetworkedBehaviour
{
    public delegate void OnHealthChangeDelegate(int health);
    public event OnHealthChangeDelegate OnHealthChange;

    public delegate void OnStateChangeDelegate(playerState state);
    public event OnStateChangeDelegate OnStateChange;
    [SerializeField] public Chasis CurrentChasis;

    [SerializeField] LayerMask groundLayers;
    [SerializeField] private float movementAcceleration = 20f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float turnSpeed = 2f;
    [SerializeField] private bool debugMeBruda;
    [SerializeField] private GameObject followCamera;
    [SerializeField] private GameObject spectateCamera;
    [SerializeField] private float deathTimer = 10.0f;
    
    private float groundDistance;
    private List<AttachPointSelection> attachPoints;
    private List<BaseWeapon> weaponsList;
    private bool deathTimerStarted = false;
    private float _deathTimer = 0f;

    private int _health = 100;
    [SerializeField] private playerState _currentState = playerState.IS_BUILDING;
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
            Debug.Log("Updated state");
            if (OnStateChange != null)
                OnStateChange(_currentState);
        }
    }
    public enum playerState
    {
        IS_BUILDING,
        IS_IDLE,
        IS_READY,
        IS_DEAD,
        IS_ATTACKING
    }
    public int collisionDamageThreshold = 10;
    public int baseCollisionDamageMultiplier = 1;
    private void Start()
    {
        if (this.IsLocalPlayer)
        {
            followCamera.SetActive(true);
        }

        rb = this.GetComponent<Rigidbody>();
        groundDistance = GetComponentInChildren<Collider>().bounds.extents.y;
        attachPoints = this.GetComponent<Chasis>().AvailableAttachPoints;
 
        weaponsList = new List<BaseWeapon>();
        foreach(AttachPointSelection attachPoint in attachPoints)
        {
            Debug.Log(attachPoint);
            if(attachPoint.attachment)
            {   
                Debug.Log(attachPoint.attachment);
                weaponsList.Add(attachPoint.attachment.GetComponent<BaseWeapon>());
            } 
        }
    }

    void Update()
    {
        if (currentState != playerState.IS_DEAD)
            moveInput = controls.PlayerActions.Move.ReadValue<Vector2>();

        if (deathTimerStarted)
        {
            _deathTimer += Time.deltaTime;

            if (_deathTimer >= deathTimer)
            {
                deathTimerStarted = false;
                _deathTimer = deathTimer;
                killPlayer();
            }
        }
    }

    private void FixedUpdate()
    {
        Move(moveInput);
    }

    public void OnWeapons(){
        Debug.Log("Attack with weapon 1 ");
        BaseWeapon weapon = getWeapon(0);
        if(weapon){
            weapon.attack();
        }

    }
    public void OnWeapons1(){
        BaseWeapon weapon = getWeapon(1);
        if(weapon){
            weapon.attack();
        }
    }
    public void OnWeapons2(){
        BaseWeapon weapon = getWeapon(2);
        if(weapon){
            weapon.attack();
        }
    }

    private BaseWeapon getWeapon(int weaponNumber){
        if(weaponNumber <= (weaponsList.Count - 1)){
            return weaponsList[weaponNumber];
        } else {
            return null;
        }
    }

    public void takeDamage(int damage)
    {
        Debug.Log("Collision damage: " + damage);
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
        if (this.IsLocalPlayer)
        {
            health = 0;
            currentState = playerState.IS_DEAD;
        }
    }

    private void Move(Vector2 moveInput)
    {
        if(IsGrounded())
        {
            if (deathTimerStarted)
            {
                deathTimerStarted = false;
                _deathTimer = 0f;
            }

            // Forward/Backward
            if(rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.forward * moveInput.y * movementAcceleration);
            }

            transform.Rotate(new Vector3 { y = moveInput.x * turnSpeed });
        }
        else
        {
            if(currentState != playerState.IS_BUILDING)
            {
                if(debugMeBruda) Debug.Log("Not grounded!");
                if (!deathTimerStarted)
                {
                    deathTimerStarted = true;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var damageMultiplier = baseCollisionDamageMultiplier;
        if (collision.gameObject.tag != "Player") {
            var collisionRB = collision.gameObject.GetComponent<Rigidbody>();
            if (collisionRB != null) {
                damageMultiplier = Mathf.RoundToInt(collisionRB.mass);
            }
        }

        var collisionMomentum = Mathf.RoundToInt(collision.relativeVelocity.magnitude) * damageMultiplier;
        if (collisionMomentum >= collisionDamageThreshold) {
            takeDamage(Mathf.RoundToInt(collisionMomentum / 5));
        }
    }

    #region HOUSEKEEPING

    private bool IsGrounded()
    {
        if(debugMeBruda)Debug.DrawRay(transform.position, -Vector3.up *5f, Color.black, 1f);
        return Physics.Raycast(transform.position, -transform.up, groundDistance + 0.2f, groundLayers);
    }

    private void Awake()
    {
        spectateCamera.SetActive(false);
        followCamera.SetActive(false);
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