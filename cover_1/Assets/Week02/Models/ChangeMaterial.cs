using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Renderer renderer;

    public Material materialOne;
    public Material materialTwo;

    public SpriteRenderer sprite;

    void Update()
    {
        // React when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Same material as materialOne?  Switch to materialTwo
            if (renderer.sharedMaterial == materialOne)
            {
                renderer.sharedMaterial = materialTwo;
            }
            // Otherwise go to materialOne
            else
            {
                renderer.sharedMaterial = materialOne;
            }
        }
    }
}
