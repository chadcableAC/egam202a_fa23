using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCross : MonoBehaviour
{
    public Transform handleA;
    public Transform handleB;

    public Renderer rendererB;

    void Update()
    {
        // CROSS will return the perpendicular vector from two vectors
        Vector3 upDirection = handleA.up;
        Vector3 deltaAB = handleB.position - handleA.position;

        Vector3 cross = Vector3.Cross(upDirection, deltaAB.normalized);

        Debug.DrawRay(handleA.position, upDirection, Color.green);
        Debug.DrawRay(handleA.position, deltaAB, Color.blue);
        Debug.DrawRay(handleA.position, cross, Color.red);        
    }
}
