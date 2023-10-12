using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBeanFinderList : MonoBehaviour
{
    void Update()
    {
        // On space pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Find all JumpingBean.cs in the scene
            JumpingBean[] allBeans = FindObjectsOfType<JumpingBean>();

            // Switch from an ARRAY to a LIST
            List<JumpingBean> beanList = new List<JumpingBean>();
            beanList.AddRange(allBeans);

            // Version 1 - FOREACH
            // Make all of them jump
            foreach (JumpingBean bean in beanList)
            {
                bean.Jump();
            }

            // Version 2 - FOR
            // Where to start counting; how long to keep counting; how to count
            for (int i = 0; i < beanList.Count; i += 1)
            {
                beanList[i].Jump();
            }

            // Version 3 - WHILE
            // While loop continues to run until the condition is false
            int count = 0;
            while (count < beanList.Count)
            {
                beanList[count].Jump();
                count++;
            }
        }
    }
}
