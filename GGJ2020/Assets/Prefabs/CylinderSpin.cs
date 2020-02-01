using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpin : MonoBehaviour
{
    public float torque = 0f;
    public float turn = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().AddTorque(transform.up * torque * turn);
    }
}
