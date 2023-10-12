using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pikmin : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform activeIndicator;
    public Transform targetIndicator;

    public void SetPikminActive(bool isActive)
    {
        activeIndicator.gameObject.SetActive(isActive);
    }

    public void SetPikminTarget(Vector3 position)
    {
        targetIndicator.gameObject.SetActive(true);
        targetIndicator.position = position;

        agent.SetDestination(position);
    }

    void Update()
    {
        Vector3 ourPosition = transform.position;
        Vector3 targetPosition = targetIndicator.position;

        Vector3 delta = ourPosition - targetPosition;
        if (delta.magnitude < 1f)
        {
            targetIndicator.gameObject.SetActive(false);
        }
    }
}
