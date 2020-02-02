using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public float ballNumber;

    // Start is called before the first frame update
    void Start()
    {
        float Scale;
        //InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        while (ballNumber > 1){
            GameObject newBall = Instantiate(ball, new Vector3(Random.Range(-34f,-15f), 1, Random.Range(40f,115f)), Quaternion.identity);
            newBall.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
            //Scale = Random.Range(0.5f,2.5f);
            Scale = 2f;
            newBall.GetComponent<Transform>().localScale = new Vector3(Scale,Scale,Scale);
            ballNumber -= 1;
        }
    }
}
