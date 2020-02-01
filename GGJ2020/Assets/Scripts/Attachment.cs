using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachment : MonoBehaviour
{
    [SerializeField] Transform attachPoint;
    public void Attach(Transform attachPoint)
    {
        this.attachPoint = attachPoint;
        transform.position=attachPoint.position;
        transform.rotation=attachPoint.rotation;
    }
}
