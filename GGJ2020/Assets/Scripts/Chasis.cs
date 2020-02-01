using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasis : MonoBehaviour
{
    [SerializeField] public List<AttachPointSelection> AvailableAttachPoints;

    // Start is called before the first frame update
    private void Start() 
    {
        HideAttachPoints();   
    }
    
    public void ShowAttachPoints()
    {
        foreach(AttachPointSelection a in AvailableAttachPoints)
        {
            a.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void HideAttachPoints()
    {
        foreach(AttachPointSelection a in AvailableAttachPoints)
        {
            a.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
