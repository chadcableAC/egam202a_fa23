using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinClicker : MonoBehaviour
{
    public Camera gameCamera;

    public float spherecastRadius = 1f;
    public Transform spherecastVisual;

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Input.mousePosition;
        Ray ray = gameCamera.ScreenPointToRay(screenPosition);

        // Debug visuals for spherecast
        spherecastVisual.position = ray.origin;
        spherecastVisual.up = ray.direction;
        spherecastVisual.localScale = new Vector3(spherecastRadius, 1000, spherecastRadius);

        if (Input.GetMouseButtonDown(0))
        {
            // Detect the FIRST thing the spherecast hits (bigger than a standard ray)
            if (Physics.SphereCast(ray, spherecastRadius, out RaycastHit hitInfo))
            {
                Pin pin = hitInfo.transform.GetComponent<Pin>();
                if (pin != null)
                {
                    pin.Hit();
                }
            }

            // Detect ALL things the ray hits
            //RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            //foreach (RaycastHit hit in raycastHits)
            //{
            //    Pin pin = hit.transform.GetComponent<Pin>();
            //    if (pin != null)
            //    {
            //        pin.Hit();
            //    }
            //}

            // Detect the FIRST thing the ray hits
            //if (Physics.Raycast(ray, out RaycastHit hitInfo))
            //{
            //    Pin pin = hitInfo.transform.GetComponent<Pin>();
            //    if (pin != null)
            //    {
            //        pin.Hit();
            //    }
            //}
        }
    }
}
