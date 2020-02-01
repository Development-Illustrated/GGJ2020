using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPad : MonoBehaviour
{
    public GameObject droppedItem;
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
            Instantiate(droppedItem, new Vector3(transform.position.x + 2.5f, 20, transform.position.z + 2.5f), Quaternion.identity);
        }
    }
}
