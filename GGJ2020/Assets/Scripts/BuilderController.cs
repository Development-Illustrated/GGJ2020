using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderController : MonoBehaviour
{
    [SerializeField] public List<Attachment> AvailableAttachments;
    [SerializeField] public List<Chasis> AvailableChasis;

    private int currentChasisIndex = 0;
    private int currentAttachmentIndex = 0;

    private GameObject CurrentChasis;
    private GameObject CurrentAttachment;

    private Transform SelectedAttachPoint;


    public void OnClickChasis()
    {
        Debug.Log("Current chasis index: " + currentChasisIndex);
        SelectChasis(AvailableChasis[currentChasisIndex]);
        currentChasisIndex += 1;
        if(currentChasisIndex > AvailableChasis.Count-1)
        {
            currentChasisIndex = 0;
        }
    }

    public void OnClickAttachment()
    {
        Debug.Log("Current attachment index: " + currentAttachmentIndex);
        AddAttachment(AvailableAttachments[currentAttachmentIndex]);
        currentAttachmentIndex += 1;
        if(currentAttachmentIndex > AvailableAttachments.Count-1)
        {
            currentAttachmentIndex = 0;
        }
        AddAttachment(AvailableAttachments[currentAttachmentIndex]);
    }

    private void SelectChasis(Chasis chasis)
    {
        if(CurrentChasis)
        {
            Destroy(CurrentChasis);
        }
    
        this.CurrentChasis = Instantiate(chasis.gameObject);
        this.CurrentChasis.transform.parent = transform;
        this.CurrentChasis.transform.position = transform.position;
    }

    private  void AddAttachment(Attachment attachment)
    {
        if(CurrentChasis)
        {
            if(CurrentAttachment)
            {
                Destroy(CurrentAttachment);
            }
            this.CurrentAttachment = Instantiate(attachment.gameObject);
            this.CurrentAttachment.GetComponent<Attachment>().Attach(CurrentChasis.GetComponent<Chasis>().AvailableAttachPoints[0]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
