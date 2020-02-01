using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttachmentManager : MonoBehaviour
{
    public int maxHeight = 50;
    public int currentHeight = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(50, currentHeight);
    }
}
