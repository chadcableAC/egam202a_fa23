using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public Renderer debugRend;

    // Collision enter, stay, exit
    private void OnCollisionEnter(Collision collision)
    {
        debugRend.material.color = Color.red;      
    }

    private void OnCollisionStay(Collision collision)
    {
        debugRend.material.color = Color.yellow;
    }

    private void OnCollisionExit(Collision collision)
    {
        debugRend.material.color = Color.blue;
    }

    // Trigger enter, stay, exit
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter!");
        debugRend.material.color = Color.red;
    }

    private void OnTriggerStay(Collider other)
    {
        debugRend.material.color = Color.yellow;
    }

    private void OnTriggerExit(Collider other)
    {
        debugRend.material.color = Color.blue;
    }
}
