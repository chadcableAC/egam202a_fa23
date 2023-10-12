using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{   
    public List<Apple> apples;

    private void Start()
    {
        // Get all of the apples WITHIN our transform (all "children" apples)
        Apple[] childrenApples = transform.GetComponentsInChildren<Apple>();

        // Move the ARRAY into a LIST
        apples.AddRange(childrenApples);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // We are NOT allowed to change a list during a foreach loop
            //foreach (Apple apple in apples)
            //{
            //    apple.Fall();
            //    apples.Remove(apple);
            //}

            // We need to count backwards when changing AND deleting elements
            // The .Count will change when we add/remove, which can cause errors
            // with the loop logic
            for (int i = apples.Count - 1; i >= 0; i--)
            {
                apples[i].Fall();

                // Remove the apple at index "i"
                apples.RemoveAt(i);
            }
        }
    }
}
