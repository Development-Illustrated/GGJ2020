using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPad : MonoBehaviour
{
    public GameObject droppedItem;
    private IEnumerator coroutine;
    private bool itemSpawned = false;
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
        if (other.tag == "Player" && !itemSpawned) {
            droppedItem.transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y + 20, transform.position.z + 2.5f);
            itemSpawned = true;
            droppedItem.SetActiveRecursively(true);

            coroutine = WaitAndDespawn();
            StartCoroutine(coroutine);
        }

    }

    private IEnumerator WaitAndDespawn()
    {
        yield return new WaitForSeconds(20.0f);

        droppedItem.SetActiveRecursively(false);
        itemSpawned = false;
    }
}
