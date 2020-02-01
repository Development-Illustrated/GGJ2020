using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject spikeCollection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            spikeCollection.GetComponent<SpikeCollection>().StabIt();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") {
            spikeCollection.GetComponent<SpikeCollection>().UnstabIt();
        }
    }
}
