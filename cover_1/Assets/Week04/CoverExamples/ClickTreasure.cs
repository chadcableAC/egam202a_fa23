using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickTreasure : MonoBehaviour
{
    // Weight information
    public int characterCountNeeded = 3;
    public List<ClickCharacter> listOfConnectedCharacters;

    // Navigation
    public NavMeshAgent agent;

    // Treasure state
    public TreasureState currentState;
    public enum TreasureState
    {
        Idle,
        Moving
    }

    // Moving variables
    public Transform goalPosition;

    // Alternate solution
    //public Transform sphereVisual;
    //public float sphereRadius = 1f;

    void Update()
    {
        switch (currentState)
        {
            case TreasureState.Idle:
                UpdateIdle();
                break;
            case TreasureState.Moving:
                UpdateMoving();
                break;
        }
    }

    public void AddCharacter(ClickCharacter character)
    {
        // Only add the character if we're missing
        if (listOfConnectedCharacters.Contains(character) == false)
        {
            listOfConnectedCharacters.Add(character);
            OnCharacterCountChanged();
        }
    }

    public void RemoveCharacter(ClickCharacter character)
    {
        listOfConnectedCharacters.Remove(character);
        OnCharacterCountChanged();
    }

    void OnCharacterCountChanged()
    {
        // Enough attached characters?  Start moving
        if (listOfConnectedCharacters.Count >= characterCountNeeded)
        {
            currentState = TreasureState.Moving;
        }
        else
        {
            currentState = TreasureState.Idle;
        }
    }

    void UpdateIdle()
    {
        agent.isStopped = true;

        // Alternate solution
        //Vector3 position = transform.position;
        //Ray ray = new(position + Vector3.up * 10, Vector3.down);

        //// Dbeug viduals
        //sphereVisual.transform.position = position;
        //sphereVisual.transform.localScale = new Vector3(sphereRadius, 20f, sphereRadius);

        //int characterCount = 0;

        //RaycastHit[] hits = Physics.SphereCastAll(ray, sphereRadius, 20f);
        //foreach (RaycastHit hit in hits)
        //{
        //    ClickCharacter character = hit.transform.GetComponent<ClickCharacter>();
        //    if (character != null)
        //    {
        //        characterCount++;
        //    }
        //}

        //Debug.Log(characterCount);
    }

    void UpdateMoving()
    {
        agent.isStopped = false;
        agent.SetDestination(goalPosition.position);
    }
}
