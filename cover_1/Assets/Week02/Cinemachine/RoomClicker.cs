using UnityEngine;
using Cinemachine;

public class RoomClicker : MonoBehaviour
{
    // Link the Unity camera (the one with the Cinemachine Brain)
    public Camera gameCamera;

    // Link the overhead camera
    public CinemachineVirtualCamera overheadCamera;

    // We'll fill these lists in Start() via code
    public Room[] rooms;
    public CinemachineVirtualCamera[] allCameras;

    void Start()
    {
        // This will find EVERY Room.cs script in the scene
        rooms = FindObjectsOfType<Room>();

        // This will find EVERY CinemachineVirtualCamera in the scene
        allCameras = FindObjectsOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {
        // Only respond to clicks
        if (Input.GetMouseButtonDown(0))
        {
            // Turn the mouse into world positions
            Vector2 mousePosition = Input.mousePosition;
            Ray mouseRay = gameCamera.ScreenPointToRay(mousePosition);

            // Did we hit ANYTHING?
            if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, 100))
            {
                // Did we hit a Room.cs by any chance?
                Room room = hitInfo.transform.GetComponent<Room>();
                RoomButton roomButton = hitInfo.transform.GetComponent<RoomButton>();

                if (room != null)
                {
                    // Switch to this room's camera
                    SwitchToCamera(room.roomCamera);
                }
                else if (roomButton != null)
                {
                    // Switch to this button's room's camera
                    SwitchToCamera(roomButton.room.roomCamera);
                }
                else
                {
                    // Back up to the overhead camera
                    SwitchToCamera(overheadCamera);
                }                
            }
        }
    }

    public void SwitchToCamera(CinemachineVirtualCamera thisCamera)
    {
        // We need to update the camera's priorities
        foreach (CinemachineVirtualCamera camera in allCameras)
        {
            int cameraPriority = 0;

            // Same camera?  Make this one the highest
            if (camera == thisCamera)
            {
                cameraPriority = 100;
            }

            camera.Priority = cameraPriority;
        }
    }
}
