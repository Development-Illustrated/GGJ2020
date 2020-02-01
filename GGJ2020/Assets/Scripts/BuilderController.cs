using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderController : MonoBehaviour
{
    [SerializeField] public List<Attachment> AvailableAttachments;
    [SerializeField] public List<Chasis> AvailableChasis;

    private int currentChasisIndex = 0;
    private int currentAttachmentIndex = 0;
    private int currentAttachPointIndex = 0;

    private GameObject CurrentChasis;
    private GameObject CurrentAttachment;

    private AttachPointSelection SelectedAttachPoint;
    private List<AttachPointSelection> AvailableAttachPoints;
    public Color AttachPointHighlightColor;
    private Color OGAttachColor = Color.red;


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
    }

    public void OnClickCycleAttachPoint()
    {   
        // Reset color on old attach point
        if(SelectedAttachPoint)
        {
            SelectedAttachPoint.GetComponent<MeshRenderer>().material.color = OGAttachColor;
        }

        currentAttachPointIndex += 1;
        if(currentAttachPointIndex > AvailableAttachPoints.Count-1)
        {
            currentAttachPointIndex = 0;
        }

        Debug.Log("Current attach point index: " + currentAttachPointIndex);
        SelectedAttachPoint = AvailableAttachPoints[currentAttachPointIndex];
        if(SelectedAttachPoint.attachment != null)
        {
            CurrentAttachment = SelectedAttachPoint.attachment.gameObject;
        }
        
        SelectedAttachPoint.GetComponent<MeshRenderer>().material.color = AttachPointHighlightColor;

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
        this.AvailableAttachPoints = this.CurrentChasis.GetComponent<Chasis>().AvailableAttachPoints;
    }

    private  void AddAttachment(Attachment attachment)
    {
        if(CurrentChasis)
        {
            if(SelectedAttachPoint.attachment)
            {
                Destroy(CurrentAttachment);
                SelectedAttachPoint.attachment = null;
            }
            this.CurrentAttachment = Instantiate(attachment.gameObject);
            this.CurrentAttachment.GetComponent<Attachment>().Attach(CurrentChasis.GetComponent<Chasis>().AvailableAttachPoints[currentAttachPointIndex].transform);
            SelectedAttachPoint.attachment = this.CurrentAttachment.GetComponent<Attachment>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
