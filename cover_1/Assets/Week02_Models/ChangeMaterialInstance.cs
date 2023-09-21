using UnityEngine;

public class ChangeMaterialInstance : MonoBehaviour
{
    public Renderer renderer;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // This is using SHARED material - all references will be updated to red!
            renderer.sharedMaterial.color = Color.red;
        }
    }
}
