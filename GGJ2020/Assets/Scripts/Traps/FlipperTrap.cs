using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperTrap : MonoBehaviour
{
    public float jumbBackForce = 4;

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

        Debug.Log(hinge.angle);
        Debug.Log(hinge.limits.min + 1);
        Debug.Log(hinge.angle <= (hinge.limits.min + 1));
        if (hinge.angle >= (hinge.limits.max - 10)) {
            hinge.useMotor = false;
            hinge.useSpring = true;
        }
        else if (hinge.angle <= (hinge.limits.min + 1)) {
            hinge.useMotor = true;
            hinge.useSpring = false;
        }
    }
}
