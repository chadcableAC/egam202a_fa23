using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public Renderer renderer;

    public void Clicked()
    {
        renderer.material.color = Color.red;
    }
}
