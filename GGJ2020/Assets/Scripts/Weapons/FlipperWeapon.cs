using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperWeapon : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {   
        rigidBody = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
        motor = hinge.motor;
        checkWeaponPosition(); 
        this.nextMinAttackTime = 0;     
    }

    // Update is called once per frame
    void Update()
    {
        this.attackTimeTracker += Time.deltaTime;
        checkWeaponPosition();
    }

    public override void attack(){
        if (this.attackTimeTracker >= this.nextMinAttackTime){
            //Activated motor to attack, and sets next possible time for an attack
            this.hinge.useMotor = true;
            this.nextMinAttackTime = 0 + attackCooldown;
            this.attackTimeTracker = 0;
        } else{

        }
    }
    
    private void checkWeaponPosition(){
        //Once the axe is past a certain point swap from motor to spring
        if(this.hinge.angle >= this.hinge.limits.max  ){
            hinge.useMotor = false;
        }
    }

    // private void OnCollisionEnter(Collision collision) {
    //     //calculate damage by modifier and speed
    //     // base.hitTarget(collision.gameObject, this.damage);
    //     hinge.useMotor = false;
    // }
}
