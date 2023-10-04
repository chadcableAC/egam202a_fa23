using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Renderer debugRenderer;

    public float raycastLength = 1;
    public Vector3 raycastDirection = Vector3.down;

    void Update()
    {
        // Fire a ray in this direction
        Ray ray = new Ray(transform.position, raycastDirection);

        bool isHit = false;

        // Hit anything?
        if (Physics.Raycast(ray, out RaycastHit hitInfo, raycastLength))
        {
            isHit = true;
        }

        Color color = Color.red;
        if (isHit)
        {
            color = Color.blue;
        }
        debugRenderer.material.color = color;

        Debug.DrawRay(ray.origin, ray.direction * raycastLength, color);
    }
}
