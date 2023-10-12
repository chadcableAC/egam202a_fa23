using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBeanClicker : MonoBehaviour
{
    public Camera gameCamera;
    public float spherecastRadius = 0.5f;

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Ray worldRay = gameCamera.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] raycastHits = Physics.SphereCastAll(worldRay, spherecastRadius);

            // We want to get the closest object in this list
            int bestIndex = -1;
            float bestDistance = -1;

            int count = 0;
            foreach (RaycastHit hit in raycastHits)
            {
                float distance = hit.distance;

                // If no has been set, make this the new "best"
                if (bestIndex == -1)
                {
                    bestIndex = count;
                    bestDistance = distance;
                }
                // If this object is closer, make it the new "best" value
                else if (distance < bestDistance)
                {
                    bestIndex = count;
                    bestDistance = distance;
                }

                count++;
            }

            // If we found something, make it jump
            if (bestIndex != -1)
            {
                RaycastHit hit = raycastHits[bestIndex];

                JumpingBean bean = hit.transform.GetComponent<JumpingBean>();
                if (bean != null)
                {
                    bean.Jump();
                }
            }
        }
    }
}
