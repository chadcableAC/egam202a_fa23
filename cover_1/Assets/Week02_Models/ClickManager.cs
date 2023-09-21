using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public Camera gameCamera;

    void FixedUpdate()
    {
        // Turn the mouse into world position
        Vector2 mousePosition = Input.mousePosition;
        Ray mouseOriginAndDirection = gameCamera.ScreenPointToRay(mousePosition);

        // Get a list of ALL hits
        RaycastHit[] raycastHits = Physics.RaycastAll(mouseOriginAndDirection, 100);
        foreach (RaycastHit hitInfo in raycastHits)
        {
            // Does this object have a ClickableObject script?
            ClickableObject clickableObject = hitInfo.transform.GetComponent<ClickableObject>();
            if (clickableObject != null)
            {
                clickableObject.Clicked();
            }
        }

        // Drawing "debug" rays can help you figure out what's happening in scene
        Debug.DrawRay(mouseOriginAndDirection.origin, mouseOriginAndDirection.direction * 100, Color.red);
    }
}
