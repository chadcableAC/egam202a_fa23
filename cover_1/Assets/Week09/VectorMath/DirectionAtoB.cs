using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionAtoB : MonoBehaviour
{
    public Transform handleA;
    public Transform handleB;

    void Update()
    {
        // From A to B = B - A ("B minus A")
        Vector3 deltaAB = handleB.position - handleA.position;
        Debug.DrawRay(handleA.position, deltaAB, Color.red);

        // We can flip and vector with a negative sign
        Vector3 deltaBA = -deltaAB;
        Debug.DrawRay(handleA.position, deltaBA, Color.blue);
    }
}
