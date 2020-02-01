using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMelee : MonoBehaviour
{

    public int damage;
    private double lastAttackTime;
    public double swingDelay;
    public double attackCooldown = 0.5;
    public double swingSpeed;

    // Start is called before the first frame update
    void Start(){
        lastAttackTime = 0.00;
    }

    // Update is called once per frame
    void Update(){
        attack();
    }

    void attack(){
        if ((lastAttackTime + Time.deltaTime) > (lastAttackTime + attackCooldown)){
            //this.object apply force after waiting the swing delay
            this.rigidBody.AddRelativeTorque(100);
        } else{
            //Do nothing, otherwise we buffer attacks forever
        }
    }

    void hitTarget(){
        // call damage step to networking.
    }
}
