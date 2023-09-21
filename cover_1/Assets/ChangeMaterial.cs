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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (renderer.sharedMaterial == materialOne)
            {
                renderer.sharedMaterial = materialTwo;
            }
            else
            {
                renderer.sharedMaterial = materialOne;
            }
        }
    }
}
