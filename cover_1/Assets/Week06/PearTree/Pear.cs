using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : MonoBehaviour
{
    public Rigidbody rb;

    // Variables for the "tell" - an indication to players something is about to happen
    public float tellDuration = 1f;
    public GameObject tellEnableHandle = null;

    void Awake()
    {
        // Make the pear stationary (no physics)
        rb.isKinematic = true;

        // Turn off the tell by default
        tellEnableHandle.SetActive(false);
    }

    public void Fall()
    {
        // Kickoff the sequence
        StartCoroutine(ExecuteFall());
    }

    IEnumerator ExecuteFall()
    {
        // Turn on
        tellEnableHandle.SetActive(true);

        // Wait
        yield return new WaitForSeconds(tellDuration);

        // Turn off
        tellEnableHandle.SetActive(false);

        // Fall
        rb.isKinematic = false;
    }
}
