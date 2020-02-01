using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{

    Rigidbody rb;
    public float speed = 1.0f;
    public float torque = 1.0f;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float moveVertical = Input.GetAxis("Vertical");
        //rb.AddForce(new Vector3(0, 0.0f, moveVertical) * speed);

        rb.AddForce(transform.forward * (moveVertical * speed));

        //Quaternion target = Quaternion.Euler(0, tiltAroundZ, 0);

        //transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, target,  Time.deltaTime * smooth);

        //transform.LookAt(newPosition + transform.position);
        //transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey (KeyCode.LeftArrow)) {
            transform.Rotate(0, -1.3f, 0);
        }
        
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, 1.3f, 0);
        }
    }
}
