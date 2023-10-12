using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikminCharacter : MonoBehaviour
{
    // An enum for color
    public enum PikminColor
    {
        Red,    // 0
        Blue,   // 1
        Yellow, // 2
    }

    // Our current color value
    public PikminColor color;

    // Renderer to switch colors on
    public Renderer mainRenderer;

    void Start()
    {
        switch (color)
        {
            // The same as "if color is red"
            case PikminColor.Red:
                mainRenderer.material.color = Color.red;
                break;

            // The same as "else if color is blue"
            case PikminColor.Blue:
                mainRenderer.material.color = Color.blue;
                break;

            // The same as "else if color is yellow"
            case PikminColor.Yellow:
                mainRenderer.material.color = Color.yellow;
                break;

            // The same as "else"
            default:

                break;
        }
    }
}
