using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshClicker : MonoBehaviour
{
    public Camera gameCamera;
    public NavMeshAgent agent;

    void Update()
    {
        // Respond to clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse to world position
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = gameCamera.ScreenPointToRay(mousePosition);

            // Hit anything?
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
            {
                // Make the agent go to the collision point
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}
