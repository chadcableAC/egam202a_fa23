using UnityEngine;

public class ChangeMaterialInstance : MonoBehaviour
{
    public Renderer mainRenderer;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // This is using SHARED material - all references will be updated to red!
            mainRenderer.sharedMaterial.color = Color.red;
        }
    }
}
