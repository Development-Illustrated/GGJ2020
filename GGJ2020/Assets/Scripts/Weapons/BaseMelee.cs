using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMelee : MonoBehaviour
{
    public double weaponHealth;
    public double damage;
    public double lastAttackTime;
    public double attackTimeTracker;
    public double swingDelay;
    public double attackCooldown = 0.5;
    public double swingSpeed;
    
    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start(){
        lastAttackTime = 0.00;

    }

    // Update is called once per frame
    void Update(){
        attack();
    }

    public virtual void attack(){}

    public void hitTarget(){
        // call damage step to networking.
    }
}
