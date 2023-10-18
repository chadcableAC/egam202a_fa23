using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public Renderer mainRenderer;

    public void Clicked()
    {
        mainRenderer.material.color = Color.red;
    }
}
