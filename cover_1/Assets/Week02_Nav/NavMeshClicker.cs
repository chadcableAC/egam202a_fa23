using UnityEngine;
using UnityEngine.AI;

public class NavMeshClicker : MonoBehaviour
{
    public Camera gameCamera;
    public NavMeshAgent agent;

    public NavMeshAgent reticule;

    private Pikmin activePikmin = null;

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
                Pikmin pikmin = hitInfo.transform.GetComponent<Pikmin>();
                if (pikmin != null)
                {
                    pikmin.SetPikminActive(true);
                    activePikmin = pikmin;
                }
                else if (activePikmin != null)
                {
                    activePikmin.SetPikminTarget(hitInfo.point);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (activePikmin != null)
            {
                activePikmin.SetPikminActive(false);
                activePikmin = null;
            }
        }
    }
}
