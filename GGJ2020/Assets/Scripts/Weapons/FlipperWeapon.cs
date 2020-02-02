using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperWeapon : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {   
        checkWeaponPosition();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void attack(){
        if ((attackTimeTracker + Time.deltaTime) > (nextMinAttackTime)){
            //Activated motor to attack, and sets next possible time for an attack
            hinge.useMotor = true;
            nextMinAttackTime = 0 + attackCooldown;
        }
    }
    
    private void checkWeaponPosition(){
        //Once the axe is past a certain point swap from motor to spring
        if(hinge.angle >= hinge.limits.max  ){
            hinge.useMotor = false;
        }
    }

    // private void OnCollisionEnter(Collision collision) {
    //     //calculate damage by modifier and speed
    //     // base.hitTarget(collision.gameObject, this.damage);
    //     hinge.useMotor = false;
    // }
}
