using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObject : MonoBehaviour
{
    public Rigidbody rb;

    public float duration;

    public Renderer mainRenderer;
    public Color blinkColorOn = Color.red;
    public Color blinkColorOff = Color.white;
    public float blinkDuration = 0.1f;

    public void Launch(Vector3 force)
    {
        // Add this force
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // We can start multiple routines on the same object
        StartCoroutine(ExecuteBlink());
        StartCoroutine(ExecuteDestroy());
    }

    IEnumerator ExecuteDestroy()
    {
        // Wait for duration
        yield return new WaitForSeconds(duration);

        // Destroy the object
        Destroy(gameObject);
    }

    IEnumerator ExecuteBlink()
    {
        // We want to repeat forever
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
