using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputListener : MonoBehaviour
{
    // Debug text
    public TextMeshProUGUI textColor;
    public TextMeshProUGUI textState;

    // History (these remember the key presses)
    public StateBasedCharacter.Colors lastColor;
    public StateBasedCharacter.States lastState;

    void Update()
    {
        // Track the last state pressed
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lastState = StateBasedCharacter.States.Idle;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            lastState = StateBasedCharacter.States.Patrol;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            lastState = StateBasedCharacter.States.Random;
        }

        // Track the last state pressed
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            lastColor = StateBasedCharacter.Colors.Red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            lastColor = StateBasedCharacter.Colors.Yellow;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            lastColor = StateBasedCharacter.Colors.Blue;
        }

        // Finally space to activate
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Find ALL of the characters in the scene
            StateBasedCharacter[] allCharacters = FindObjectsOfType<StateBasedCharacter>();
            foreach (StateBasedCharacter character in allCharacters)
            {
                // If they have the same color, update the state!
                if (character.currentColor == lastColor)
                {
                    character.currentState = lastState;
                }
            }
        }

        // Debug
        textColor.text = lastColor.ToString();
        textState.text = lastState.ToString();
    }
}
