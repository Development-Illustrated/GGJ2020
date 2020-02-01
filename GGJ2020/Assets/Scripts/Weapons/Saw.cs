using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : BaseWeapon
{
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        var calculatedDamage = this.damage * rigidBody.angularVelocity.magnitude;
        base.hitTarget(collision.gameObject, this.damage);
    }

}
