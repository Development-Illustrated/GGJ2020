using UnityEngine;

public class Attachment : MonoBehaviour
{
    [SerializeField] Transform attachPoint;
    [SerializeField] Vector3 postSpawnRotation; // Used to alter the rotation after spawning on attachpoint
    public void Attach(Transform attachPoint)
    {
        this.attachPoint = attachPoint;
        transform.position=attachPoint.position;
        transform.rotation=attachPoint.rotation;
        transform.parent = attachPoint;

        Quaternion target = Quaternion.Euler(postSpawnRotation);
        transform.rotation = target;

        // attachPoint.GetComponent<MeshRenderer>().enabled = false;

        if(GetComponent<HingeJoint>() != null)
        {
            Debug.Log("Attaching hinge joint");
            GetComponent<HingeJoint>().connectedAnchor = attachPoint.position;
            GetComponent<HingeJoint>().connectedBody = transform.root.GetComponent<Rigidbody>();
        }
    }
}
