using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected HingeJoint hinge;
    protected JointMotor motor;
    [SerializeField] protected double weaponHealth;
    [SerializeField] protected double weight;
    [SerializeField] protected double damage;

    //Time stamp for when the weapon can next execute an attack
    [SerializeField] protected double nextMinAttackTime;
    //Time incrementer to be compared to the nextMinAttackTime for next possible attack
    [SerializeField] protected double attackTimeTracker;
    //Value to be added to the timestamp to calculate nextMinAttackTime
    [SerializeField] protected double attackCooldown;

    
    protected Rigidbody rigidBody;

    public virtual void attack(){}

    public void takeDamage(double damageTaken){
        if(!((this.weaponHealth - damageTaken) < 0)){
            this.weaponHealth -= damageTaken;
        } else {
            this.weaponHealth = 0;
            //Pop weapon off
        }
            
    }

    // call damage step to networking/Tell object they take X Damage
    public void hitTarget(GameObject hitTarget, double damageToTake){
        //Tell them they got hurt
        // hitTarget.takeDamage(damageToTake);
    }

}
