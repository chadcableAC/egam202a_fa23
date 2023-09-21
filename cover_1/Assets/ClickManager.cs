using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ClickManager : MonoBehaviour
{
    public Camera gameCamera;

    void FixedUpdate()
    {
        Vector2 mousePosition = Input.mousePosition;
        Ray mouseOriginAndDirection = gameCamera.ScreenPointToRay(mousePosition);

        RaycastHit[] raycastHits = Physics.RaycastAll(mouseOriginAndDirection, 100);
        foreach (RaycastHit hitInfo in raycastHits)
        {
            ClickableObject clickableObject = hitInfo.transform.GetComponent<ClickableObject>();
            if (clickableObject)
            {
                if (clickableObject.isCube)

                clickableObject.Clicked();
            }
        }

        Debug.DrawRay(mouseOriginAndDirection.origin, mouseOriginAndDirection.direction * 100, Color.red);

    }
}
