using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperTrap : MonoBehaviour
{
    public GameObject flipper;
    public float jumbBackForce = 4;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player") {
            flipper.GetComponent<Flipper>().FlipIt();
        }
    }
}
