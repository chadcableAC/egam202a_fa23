using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBeanFinderArray : MonoBehaviour
{
    void Update()
    {
        // On space pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Find all JumpingBean.cs in the scene
            JumpingBean[] allBeans = FindObjectsOfType<JumpingBean>();

            // Make all of them jump
            foreach (JumpingBean bean in allBeans)
            {             
                bean.Jump();
            }

            // Where to start counting; how long to keep counting; how to count
            // When using an ARRAY, we check the .Length
            for (int i = 0; i < allBeans.Length; i += 1)
            {
                allBeans[i].Jump();
            }
        }
    }
}
