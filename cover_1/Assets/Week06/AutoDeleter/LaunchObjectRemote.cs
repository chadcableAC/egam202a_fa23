using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchObjectRemote : MonoBehaviour
{
    public Rigidbody rb;

    // For changing display / render
    public Renderer mainRenderer;
    public Color blinkColorOn = Color.red;
    public Color blinkColorOff = Color.white;
    public float blinkDuration = 0.1f;

    public void Launch(Vector3 force)
    {
        // Add this force
        rb.AddForce(force, ForceMode.Impulse);
    }

    public IEnumerator ExecuteBlink()
    {
        // We want to repeat forever
        while (true)
        {
            // Blink on, wait
            mainRenderer.material.color = blinkColorOn;
            yield return new WaitForSeconds(blinkDuration);

            // Blink off, waitc
            mainRenderer.material.color = blinkColorOff;
            yield return new WaitForSeconds(blinkDuration);
        }
    }
}
