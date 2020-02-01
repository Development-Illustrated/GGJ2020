using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxWidth = 425;
    public int currentWidth = 300;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(currentWidth, 45);
    }
}
