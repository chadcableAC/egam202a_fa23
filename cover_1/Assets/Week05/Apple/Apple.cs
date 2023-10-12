using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        // Stop the apply from moving by default (deactivate physics)
        rb.isKinematic = true;
    }

    public void Fall()
    {
        // Allow the apple to move (activate physics)
        rb.isKinematic = false;
    }
}
