using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PearTree : MonoBehaviour
{
    // Any START function can be turned into a Coroutine
    // There's no need to call StartCoroutine here - Unity will do it for you
    IEnumerator Start()
    {
        // Wait two seconds
        yield return new WaitForSeconds(2);

        // Find all of the pears underneath our transform
        Pear[] pearArray = transform.GetComponentsInChildren<Pear>();

        foreach (Pear pear in pearArray)
        {
            // For each pear, wait 0.25 seconds
            yield return new WaitForSeconds(0.25f);

            // Then fall
            pear.Fall();           
        }
    }
}
