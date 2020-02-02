using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    private float spawnDelay = 0.1f;
    public float thrust;
    public float speed;

    private float ySpeed = 100.0f;
    private GameObject[] CannonBalls = new GameObject[30];
    private int ArrayIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        for (int i = 0; i < CannonBalls.Length; i++) {
			CannonBalls[i] = null;
		}
    }

    public void SpawnObject() {
        GameObject newBall = Instantiate(spawnee, transform.position, transform.rotation);
        newBall.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());

        Rigidbody newBallRB = newBall.GetComponent<Rigidbody>(); 
        newBallRB.AddForce(transform.forward * thrust, ForceMode.Impulse);
        newBallRB.AddForce(transform.up * (Random.Range(-40.0f, 5.0f)), ForceMode.Impulse);
        newBallRB.mass = Random.Range(1.0f, 100.0f);

        ArrayIndex++;
        if (ArrayIndex + 1 > CannonBalls.Length)
        {
            ArrayIndex = 0;
        }

        if (CannonBalls[ArrayIndex] != null)
        {
            Destroy(CannonBalls[ArrayIndex]);
        }

        CannonBalls[ArrayIndex] = newBall;

        if(stopSpawning){
            CancelInvoke("SpawnObject");
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up, ySpeed * Time.deltaTime);
    }
}

    
