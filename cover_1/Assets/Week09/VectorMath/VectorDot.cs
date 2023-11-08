using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDot : MonoBehaviour
{
    public Transform handleOrigin;

    public Transform handleOther;
    public Renderer rendererOther;

    public float minimumDotValue = 0;

    void Update()
    {
        // DOT tells us how aligned two vectors are
        //  1 = the exact same direction
        //  0 = perpendicular directions
        //  -1 = the exact OPPOSITE direction
        // NOTE: the two vectors must be normalized for this math to appear correctly

        Vector3 lookDirection = handleOrigin.forward;
        Debug.DrawRay(handleOrigin.position, lookDirection);

        Vector3 delta = handleOther.position - handleOrigin.position;
        Debug.DrawRay(handleOrigin.position, delta);

        // For facing, both vectros need to be NORMALIZED / length of 1
        float dot = Vector3.Dot(lookDirection, delta.normalized);

        // Switch the color based on whether the object is IN or OUT of view
        Color color = Color.blue;
        if (dot < minimumDotValue)
        {
            color = Color.red;
        }
        rendererOther.material.color = color;

        // This shows in scene what the values mean
        Vector3 testDirection = Vector3.forward;
        for (int i = 0; i < 360; i++)
        {
            testDirection = Quaternion.Euler(Vector3.up) * testDirection;
            float testDot = Vector3.Dot(lookDirection, testDirection.normalized);
            Color testColor = Color.blue;
            if (testDot < minimumDotValue)
            {
                testColor = Color.red;
            }
            Debug.DrawRay(handleOrigin.position, testDirection * 4, testColor);
        }
    }
}
