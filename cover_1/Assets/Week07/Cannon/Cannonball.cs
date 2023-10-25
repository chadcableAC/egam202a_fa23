using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public Rigidbody rb;

    public void Launch(Vector3 direction, float strength)
    {
        rb.AddForce(direction * strength, ForceMode.Impulse);
    }
}
