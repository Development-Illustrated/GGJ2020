using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float startSpeed = 0;
    Rigidbody body;
    HingeJoint hinge;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {

        if (hinge.angle >= (hinge.limits.max - 5f)) {
            hinge.useMotor = false;
            hinge.useSpring = true;
        }
    }

    public void FlipIt ()
    {
        hinge.useMotor = true;
        hinge.useSpring = false;
    }
}
