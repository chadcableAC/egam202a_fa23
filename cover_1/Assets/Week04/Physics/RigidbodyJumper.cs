using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyJumper : MonoBehaviour
{
    public Rigidbody rb;

    public float force = 1f;


    void FixedUpdate()
    {
        // Use for instant actions (events)
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        //}

        // Use over time (holds, presses)
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force, ForceMode.Force);
        }
    }
}
