using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpin : MonoBehaviour
{
    public float torque = 0f;
    public float turn = 0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(transform.up * torque * turn);
    }
}
