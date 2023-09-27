using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    // Enum for the plant state / step
    public enum States
    {
        Seed,
        SmallPlant,
        MediumPlant,
        Fullgrown
    }

    // Our current state
    public States currentState;

    // The visuals for each of the steps
    public GameObject seedHandle;
    public GameObject smallHandle;
    public GameObject mediumHandle;
    public GameObject largeHandle;

    void Start()
    {
        // Start with the seed state
        SetState(States.Seed);
    }

    void Update()
    {
        // On a click, move to the next state
        if (Input.GetMouseButtonDown(0))
        {
            currentState++; // Go to the next state up
            SetState(currentState);
        }
    }

    private void SetState(States state)
    {
        // Turn the game objects on/off based on the current state
        seedHandle.SetActive(state == States.Seed);
        smallHandle.SetActive(state == States.SmallPlant);
        mediumHandle.SetActive(state == States.MediumPlant);
        largeHandle.SetActive(state == States.Fullgrown);
    }
}
