using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : BaseMelee // Derived class
{
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    public override void attack(){
        Debug.Log("ATTACKING");
        Debug.Log("last attack time: " + lastAttackTime);
        Debug.Log("Time Since last attack: " + (attackTimeTracker + Time.deltaTime));
        Debug.Log("Next Attack time: " + (lastAttackTime));

        if ((attackTimeTracker + Time.deltaTime) > (lastAttackTime)){
            //this.object apply force after waiting the swing delay
            rigidBody.AddTorque(0,0,-10000);
            lastAttackTime = Time.time + attackCooldown;
            Debug.Log("Inside the if");
        } else{
            //Do nothing, otherwise we buffer attacks forever
             attackTimeTracker += Time.deltaTime;
        }

    }

}
