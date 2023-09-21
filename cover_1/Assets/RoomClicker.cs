using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RoomClicker : MonoBehaviour
{
    public Camera gameCamera;
    public CinemachineVirtualCamera overheadCamera;
    
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
        foreach (CinemachineVirtualCamera camera in allCameras)
        {
            int cameraPriority = 0;
            if (camera == thisCamera)
            {
                cameraPriority = 100;
            }
            camera.Priority = cameraPriority;
        }
    }
}
