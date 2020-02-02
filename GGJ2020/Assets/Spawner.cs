using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public float thrust;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject() {
        GameObject newBall = Instantiate(spawnee, transform.position, transform.rotation);
        newBall.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());

        newBall.GetComponent<Rigidbody>().AddForce(transform.forward * thrust,ForceMode.Impulse);

        if(stopSpawning){
            CancelInvoke("SpawnObject");
        }
    }

        void Update(){

        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
        void FixedUpdate()
    {
        //Debug.Log(Time.deltaTime);
        if (System.Math.Abs(transform.rotation.y) > 0.08){
            speed = -speed;
        }
    }
}

    
