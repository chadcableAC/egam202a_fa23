using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateBasedCharacter : MonoBehaviour
{
    // List of possible states
    public enum States
    {
        Idle,
        Patrol,
        Follow,
        Random
    }

    public States currentState;

    // List of possile colors
    public enum Colors
    {
        Red,
        Yellow,
        Blue
    }

    public Colors currentColor;

    // Reference to our nav mesh agent
    public NavMeshAgent agent;

    // Follow variables
    public Vector3 followPosition;

    // Patrol variables
    public List<Vector3> patrolPositions;
    public int patrolIndex;

    public float patrolMinDistance = 1f;

    // Random variables
    public float randomMin = -1f;
    public float randomMax = 1f;

    public float randomCountdown = 2f;
    public float randomTimer = 0;

    // Colorinf
    public Renderer colorRenderer;

    void Start()
    {
        // On start, update the color
        switch (currentColor)
        {
            case Colors.Red:
                colorRenderer.material.color = Color.red;
                break;
            case Colors.Yellow:
                colorRenderer.material.color = Color.yellow;
                break;
            case Colors.Blue:
                colorRenderer.material.color = Color.blue;
                break;
        }
    }

    void Update()
    {
        // The update is broken down by each enum value
        switch (currentState)
        {
            case States.Idle:
                UpdateIdle();
                break;
            case States.Patrol:
                UpdatePatrol();
                break;
            case States.Follow:
                UpdateFollow();
                break;
            case States.Random:
                UpdateRandom();
                break;
        }
    }

    void UpdateIdle()
    {
        agent.isStopped = true;
    }

    void UpdateFollow()
    {
        agent.isStopped = false;
        agent.SetDestination(followPosition);
    }

    void UpdatePatrol()
    {
        agent.isStopped = false;

        // First, where are we going?
        Vector3 targetPosition = patrolPositions[patrolIndex];
        agent.SetDestination(targetPosition);

        Vector3 ourPosition = transform.position;
        Vector3 delta = targetPosition - ourPosition;
        delta.y = 0;

        if (delta.magnitude < patrolMinDistance)
        {
            // Go to the next point
            patrolIndex++;

            // If this point is outside of the list (the index is too big),
            // Go back to the first element
            if (patrolIndex >= patrolPositions.Count)
            {
                patrolIndex = 0;
            }
        }
    }

    void UpdateRandom()
    {
        agent.isStopped = false;

        // After x seconds, pick a new target position
        randomTimer += Time.deltaTime;
        if (randomTimer >= randomCountdown)
        {
            randomTimer = 0;

            float randomX = Random.Range(randomMin, randomMax);
            float randomZ = Random.Range(randomMin, randomMax);

            Vector3 newRandomPosition = new Vector3(randomX, 0, randomZ);
            agent.SetDestination(newRandomPosition);
        }
    }
}
