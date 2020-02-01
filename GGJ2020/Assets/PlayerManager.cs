using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float turnSpeed = 2f;
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    
    private Rigidbody rb;
    private PlayerInputActions controls = null;
    private Vector2 moveInput;

    public playerState currentState;
    public enum playerState
    {
        IS_READY,
        IS_DEAD,
        IS_ATTACKING
    }

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        moveInput = controls.PlayerActions.Move.ReadValue<Vector2>();
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
