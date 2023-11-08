using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // We can simply reference the parent particle system
    // All of the children will animate with it automatically
    public ParticleSystem effect;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            effect.Play();
        }

        if (Input.GetMouseButtonDown(0))
        {
            //effect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);

            // This does the same thing as above
            effect.Stop();
            effect.Clear();
        }
    }
}
