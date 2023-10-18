using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{
    public Camera gameCamra;
    public float launchStrength;
    public LaunchObject launchPrefab;
    public LaunchObjectDefuse launchDefusePrefab;
    public LaunchObjectRemote launchRemotePrefab;

    void Update()
    {
        // Go from screen to world
        Vector2 screenPosition = Input.mousePosition;
        Ray worldRay = gameCamra.ScreenPointToRay(screenPosition);

        // Left click - launch the default prefab
        if (Input.GetMouseButtonDown(0))
        {
            // Create an object, launch it along the ray
            LaunchObject newLaunchedObject = Instantiate(launchPrefab);
            newLaunchedObject.transform.position = worldRay.origin;
            newLaunchedObject.Launch(worldRay.direction * launchStrength);
        }
        // Right click - launch the defuse prefab
        else if (Input.GetMouseButtonDown(1))
        {
            // Create an object, launch it along the ray
            LaunchObjectDefuse newLaunchedObject = Instantiate(launchDefusePrefab);
            newLaunchedObject.transform.position = worldRay.origin;
            newLaunchedObject.Launch(worldRay.direction * launchStrength);
        }
        // Left click - launch the remote prefab
        else if (Input.GetMouseButtonDown(2))
        {
            // Create an object, launch it along the ray
            LaunchObjectRemote newLaunchedObject = Instantiate(launchRemotePrefab);
            newLaunchedObject.transform.position = worldRay.origin;
            newLaunchedObject.Launch(worldRay.direction * launchStrength);

            // Start the sequence on this new launch object
            StartCoroutine(newLaunchedObject.ExecuteBlink());
        }
    }
}
