using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObjectDefuse : MonoBehaviour
{
    public Rigidbody rb;

    public float duration;

    public Renderer mainRenderer;
    public Color blinkColorOn = Color.red;
    public Color blinkColorOff = Color.white;
    public float blinkDuration = 0.1f;

    Coroutine blinkRoutine;

    public void Launch(Vector3 force)
    {
        // Add this force
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // We only want to start one blink routine at a time
        // If the routine is NULL, then there's no active sequence
        if (blinkRoutine == null)
        {
            // Assign the sequence to this variable
            blinkRoutine = StartCoroutine(ExecuteBlink());
        }

        StartCoroutine(ExecuteDestroy());
    }

    IEnumerator ExecuteDestroy()
    {
        bool isDestroyAtEnd = true;

        // Wait for duration
        float destroyTimer = 0;
        while (destroyTimer < duration)
        {
            // Detect input to stop us from being destroyed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDestroyAtEnd = false;

                // Stop the blinking routine
                StopCoroutine(blinkRoutine);
                blinkRoutine = null;

                // Go back to the regular color
                mainRenderer.material.color = Color.white;

                break;
            }

            // Wait one frame (one update)
            yield return null;
            destroyTimer += Time.deltaTime;
        }

        if (isDestroyAtEnd)
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }

    IEnumerator ExecuteBlink()
    {
        // We want to blink forever (or until someone stops this coroutine)
        while (true)
        {
            // Blink on, wait
            mainRenderer.material.color = blinkColorOn;
            yield return new WaitForSeconds(blinkDuration);

            // Blink off, wait
            mainRenderer.material.color = blinkColorOff;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
