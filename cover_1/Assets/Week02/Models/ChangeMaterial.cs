using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Renderer mainRenderer;

    public Material materialOne;
    public Material materialTwo;

    public SpriteRenderer sprite;

    void Update()
    {
        // React when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Same material as materialOne?  Switch to materialTwo
            if (mainRenderer.sharedMaterial == materialOne)
            {
                mainRenderer.sharedMaterial = materialTwo;
            }
            // Otherwise go to materialOne
            else
            {
                mainRenderer.sharedMaterial = materialOne;
            }
        }
    }
}
