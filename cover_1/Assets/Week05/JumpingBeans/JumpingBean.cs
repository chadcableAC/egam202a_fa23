using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBean : MonoBehaviour
{
    public Rigidbody rb;
    private float jumpForce;

    public Renderer myRenderer;

    // Remember that enums are just a list of ints
    public enum BeanType
    {
        Weak,       // 0
        Normal,     // 1
        Strong,     // 2
        SIZE        // 3
    }

    public BeanType currentType;

    // These lists match the order of the BeanType enum
    public List<Color> typeColors;
    public List<float> typeJumpForces;

    void Start()
    {
        // Pick a random enum to be
        int enumValue = Random.Range(0, (int)BeanType.SIZE);
        currentType = (BeanType)enumValue;

        // Use that value to look up a color
        Color color = typeColors[(int)currentType];
        myRenderer.material.color = color;

        // Use that value to look up a jump strength
        jumpForce = typeJumpForces[(int)currentType];
    }

    public void Jump()
    {
        if (rb.IsSleeping())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
