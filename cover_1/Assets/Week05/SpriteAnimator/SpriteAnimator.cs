using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public List<Sprite> spriteList;
    public SpriteRenderer spriteRenderer;

    public int spriteIndex;

    public float spriteTimer;
    public float spriteDuration;

    void Start()
    {
        spriteRenderer.sprite = spriteList[0];
    }

    void Update()
    {
        // Increment the timer
        spriteTimer += Time.deltaTime;
        if (spriteTimer >= spriteDuration)
        {
            // Reset the timer
            spriteTimer = 0;

            // Move to the next sprite
            spriteIndex++;

            // Make sure we stay inside the bounds of the list
            spriteIndex %= spriteList.Count;

            //if (spriteIndex >= spriteList.Count)
            //{
            //    spriteIndex = 0;
            //}

            // Assign the sprite
            spriteRenderer.sprite = spriteList[spriteIndex];
        }

    }
}
