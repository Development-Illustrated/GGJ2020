using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float raiseSpeed = 17;
    public float lowerSpeed = 0.5f;
    public GameObject trapPad;
    private Rigidbody rb;
    private bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isUp)
            transform.Translate (Vector3.up * raiseSpeed * Time.deltaTime);
        else
            transform.Translate (-Vector3.up * lowerSpeed * Time.deltaTime);

        if(transform.position.y >= -0.2) {
            isUp = false;
        }

        if(transform.position.y <= -2) {
            isUp = true;
        }
    }
}
