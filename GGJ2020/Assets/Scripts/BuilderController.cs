using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderController : MonoBehaviour
{
    [SerializeField] public List<Attachment> AvailableAttachments;
    [SerializeField] public List<Chasis> AvailableChasis;

    private GameObject CurrentChasis;

    void SelectChasis(Chasis chasis)
    {
        if(CurrentChasis)
        {
            Destroy(CurrentChasis);
        }
    
        this.CurrentChasis = Instantiate(chasis.gameObject);
    }

    void AddAttachment(Attachment attachment)
    {
        if(CurrentChasis)
        {
            GameObject newAttachment = Instantiate(attachment.gameObject);
            newAttachment.GetComponent<Attachment>().Attach(CurrentChasis.GetComponent<Chasis>().AvailableAttachPoints[0]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Key code x read");
            SelectChasis(AvailableChasis[0]);
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Key code Y has been pressed");
            AddAttachment(AvailableAttachments[0]);
        }
    }
}
