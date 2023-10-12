using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewportMouse : MonoBehaviour
{
    // UI for debug
    public TextMeshProUGUI text;

    // Game camera (switching coordinate spaces)
    public Camera gameCamera;

    void Update()
    {
        // Get the mouse position
        Vector2 mousePosition = Input.mousePosition;

        // The mouse position is already in screen space
        Vector2 screenPosition = mousePosition;

        // We can switch to viewport, which is 0 to 1 (0 = left / bottom, 1 = right / top)
        Vector2 viewportPosition = gameCamera.ScreenToViewportPoint(mousePosition);

        // Update the debug text
        text.text = string.Format("Screen: {0}\nViewport: {1}", screenPosition, viewportPosition);
    }
}
