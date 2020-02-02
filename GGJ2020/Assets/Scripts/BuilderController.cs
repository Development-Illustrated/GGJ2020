using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BuilderController : MonoBehaviour
{
    [SerializeField] public List<Attachment> AvailableAttachments;
    [SerializeField] public List<Chasis> AvailableChasis;

    private int currentChasisIndex = 0;
    private int currentAttachmentIndex = 0;
    private int currentAttachPointIndex = 0;

    private GameObject CurrentChasis;
    private GameObject CurrentAttachment;

    private List<AttachPointSelection> AvailableAttachPoints;
    public Color AttachPointHighlightColor;
    private Color OGAttachColor = Color.red;

    private PlayerManager player;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject buildGui;


    public void EnableBuildMode()
    {
        // CinemachineTransposer transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        // transposer.m_FollowOffset.z = 10;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        buildGui.SetActive(true);
        player.currentState = PlayerManager.playerState.IS_BUILDING;        
    }
    public void DisableBuildMode()
    {
        // var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        // transposer.m_FollowOffset.z = 10;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        buildGui.SetActive(false);
        player.currentState = PlayerManager.playerState.IS_READY;        
    }

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
        // AvailableAttachPoints[currentAttachPointIndex].GetComponent<MeshRenderer>().material.color = OGAttachColor;

        currentAttachPointIndex += 1;
        if(currentAttachPointIndex > AvailableAttachPoints.Count-1)
        {
            currentAttachPointIndex = 0;
        }

        Debug.Log("Current attach point index: " + currentAttachPointIndex + " out of possible: " + (AvailableAttachPoints.Count-1) + " for bot: " + CurrentChasis.name);
        // Pick up the Attachment previously placed on this attach point
        if(AvailableAttachPoints[currentAttachPointIndex].attachment != null)
        {
            CurrentAttachment = AvailableAttachPoints[currentAttachPointIndex].attachment.gameObject;
        }
        
        // AvailableAttachPoints[currentAttachPointIndex].GetComponent<MeshRenderer>().material.color = AttachPointHighlightColor;
    }

    private void SelectChasis(Chasis chasis)
    {
        Debug.Log("Setting chasis to: " + chasis.gameObject.name);
        if(CurrentChasis)
        {
            Destroy(CurrentChasis);
        }
    
        this.CurrentChasis = Instantiate(chasis.gameObject);
        Debug.Log("New chasis is: " + this.CurrentChasis.name);

        this.CurrentChasis.transform.parent = transform;
        this.CurrentChasis.transform.position = transform.position;
        AvailableAttachPoints = this.CurrentChasis.GetComponent<Chasis>().AvailableAttachPoints;
        player.CurrentChasis = this.CurrentChasis.GetComponent<Chasis>();

        currentAttachPointIndex = 0;
        Debug.Log("CurrentAttachPointIndex " + currentAttachPointIndex);
        Debug.Log("Available attach points: " +AvailableAttachPoints);
    }

    private  void AddAttachment(Attachment attachment)
    {
        if(CurrentChasis)
        {
            if(AvailableAttachPoints[currentAttachPointIndex].attachment)
            {
                Destroy(CurrentAttachment);
                AvailableAttachPoints[currentAttachPointIndex].attachment = null;
            }
            CurrentAttachment = Instantiate(attachment.gameObject);
            CurrentAttachment.GetComponent<Attachment>().Attach(AvailableAttachPoints[currentAttachPointIndex].transform);
            AvailableAttachPoints[currentAttachPointIndex].attachment = CurrentAttachment.GetComponent<Attachment>();
        }
    }

    // Start is called before the first frame upate
    void Start()
    {
        player = GetComponent<PlayerManager>();
        CurrentChasis = player.CurrentChasis.gameObject;
        this.AvailableAttachPoints = this.CurrentChasis.GetComponent<Chasis>().AvailableAttachPoints;
        EnableBuildMode();
    }
}
