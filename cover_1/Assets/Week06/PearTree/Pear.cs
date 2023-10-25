using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pear : MonoBehaviour
{
    public Rigidbody rb;

    // Variables for "growing" into the scene
    public Transform scaleHandle;
    public float growDuration = 1f;

    // Variables for the "tell" - an indication to players something is about to happen
    public float tellDuration = 1f;
    public GameObject tellEnableHandle = null;

    void Awake()
    {
        // Make the pear stationary (no physics)
        rb.isKinematic = true;

        // Turn off the tell by default
        tellEnableHandle.SetActive(false);

        // Scale to start at 0
        scaleHandle.localScale = Vector3.zero;
    }

    public void Appear()
    {
        // Kickoff the sequence
        StartCoroutine(ExecutePear());
    }

    IEnumerator ExecutePear()
    {
        yield return StartCoroutine(ExecuteGrow());

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(ExecuteFall());

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }

    IEnumerator ExecuteGrow()
    {
        float growTimer = 0;
        while (growTimer < growDuration)
        {
            // Turns timer + duration into a value between 0 and 1
            float interp = growTimer / growDuration;
            float scale = Mathf.Lerp(0, 1, interp);

            scaleHandle.localScale = Vector3.one * scale;

            yield return null;
            growTimer += Time.deltaTime;
        }
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
