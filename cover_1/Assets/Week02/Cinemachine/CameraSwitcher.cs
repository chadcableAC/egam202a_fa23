using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    // Set the cameras in the Unity inspector
    public List<CinemachineVirtualCamera> cameraList;

    // The index of the active camera in this list
    public int activeCameraIndex = 0;

    void Update()
    {
        // We're reacting to mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // We want to make the "next" camera show
            activeCameraIndex++;

            // We need to "loop" the index so we don't overrun the list
            if (activeCameraIndex >= cameraList.Count)
            {
                activeCameraIndex = 0;
            }

            // We need to update all of the camera priorities
            for (int i = 0; i < cameraList.Count; i++)
            {
                int newPriority = 0;
                if (i == activeCameraIndex)
                {
                    newPriority = 100;
                }
                cameraList[i].Priority = newPriority;
            }
        }
    }
}
