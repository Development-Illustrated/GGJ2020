using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCollection : MonoBehaviour
{
    public float raiseSpeed = 10;
    public float lowerSpeed = 1f;
    public GameObject trapPad;
    private Rigidbody rb;
    private bool stab = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stab && transform.position.y <= -0.5f)
            transform.Translate (Vector3.up * raiseSpeed * Time.deltaTime);
        else if (transform.position.y >= -2f)
            transform.Translate (-Vector3.up * lowerSpeed * Time.deltaTime);
    }

    public void StabIt() {
        stab = true;
    }

    public void UnstabIt() {
        stab = false;
    }
}
