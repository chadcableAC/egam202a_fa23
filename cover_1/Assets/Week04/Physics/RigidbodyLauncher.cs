using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyLauncher : MonoBehaviour
{
    public Rigidbody rb;

    public float force = 1f;

    public Camera gameCamera;

    void FixedUpdate()
    {
        // Mouse to world
        Vector2 screenPosition = Input.mousePosition;
        Vector3 worldPosition = gameCamera.ScreenToWorldPoint(screenPosition);

        Vector3 ourPosition = transform.position;

        // A to B in vector = B - A
        // A = Us, the object
        // B = mouse
        Vector3 usToMouseDelta = worldPosition - ourPosition;

        // We only want to move left/right/up/down, so null out the depth value
        usToMouseDelta.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            // Normalize() - this will CHANGE the value of the vector
            //usToMouseDelta.Normalize();
            //rb.AddForce(usToMouseDelta * force, ForceMode.Impulse);

            // normalized - this will not change the vector
            rb.AddForce(usToMouseDelta.normalized * force, ForceMode.Impulse);
        }

        Debug.DrawLine(worldPosition, ourPosition);
        Debug.DrawRay(ourPosition, usToMouseDelta, Color.red);
    }
}
