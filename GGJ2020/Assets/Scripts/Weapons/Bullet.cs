using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 0f;
    public float maxLifeTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        Debug.Log("Gun bullet lifeTime" + lifeTime);
        if (lifeTime > maxLifeTime) {
            lifeTime = 0;
            killBill();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Gun bullet collision with" + col.gameObject.tag);
        killBill();
    }

    void killBill() {
        lifeTime = 0;
        DestroyImmediate(this);
    }
}
