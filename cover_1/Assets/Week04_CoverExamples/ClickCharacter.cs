using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickCharacter : MonoBehaviour
{
    // Navigation
    public NavMeshAgent agent;

    // Character state
    public CharacterState currentState;
    public enum CharacterState
    {
        Idle,
        MoveToTreasure,
        CarryTreasure        
    }

    // Treasure variables
    public ClickTreasure targetTeasure;

    // Move to this position
    public void MoveTo(Vector3 position)
    {
        // Forget any treasures
        ForgetTreasure();

        // Move to this position
        agent.SetDestination(position);
    }

    // Move to this treasure
    public void MoveTo(ClickTreasure treasure)
    {
        // Switch states        
        currentState = CharacterState.MoveToTreasure;

        // Remember this treasure
        targetTeasure = treasure;
    }

    // Forget our current target
    public void ForgetTreasure()
    {
        // Switch states
        currentState = CharacterState.Idle;

        // Remove us from the list
        if (targetTeasure != null)
        {
            targetTeasure.RemoveCharacter(this);
        }

        // No longer target
        targetTeasure = null;     
    }

    private void Update()
    {
        switch (currentState)
        {
            case CharacterState.Idle:
                UpdateIdle();
                break;
            case CharacterState.MoveToTreasure:
                UpdateMoveToTreasure();
                break;
            case CharacterState.CarryTreasure:
                UpdateCarryTreasure();
                break;
        }
    }

    void UpdateIdle()
    {
        agent.isStopped = true;
    }

    void UpdateMoveToTreasure()
    {
        agent.isStopped = false;

        // Move to the treasure if we have one
        if (targetTeasure != null)
        { 
            agent.SetDestination(targetTeasure.transform.position);
        }
    }

    void UpdateCarryTreasure()
    {
        agent.isStopped = false;

        // Move to the treasure if we have one
        if (targetTeasure != null)
        {
            agent.SetDestination(targetTeasure.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ClickTreasure collisionTreasure = collision.transform.GetComponent<ClickTreasure>();

        switch (currentState)
        {           
            case CharacterState.MoveToTreasure:

                // If we hit the goal, add us to the list
                if (collisionTreasure == targetTeasure)
                {
                    currentState = CharacterState.CarryTreasure;
                    targetTeasure.AddCharacter(this);
                }

                break;
        }
    }
}
