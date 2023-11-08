using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public Transform moveHandle;
    public Transform moveHandleDeltaTime;

    public float moveSpeed;


    void Update()
    {
        Vector3 movement = Vector3.forward * moveSpeed;

        // This one moves frame DEPENDANT
        moveHandle.position += movement;

        // This one moves frame INDEPENDANT (good one)
        // Movement / 60
        moveHandleDeltaTime.position += movement * Time.deltaTime;
    }

    void FixedUpdate()
    {
        // In FixedUpdate, we need to use fixedDeltaTime
        Vector3 movement = Vector3.forward * moveSpeed;
        moveHandleDeltaTime.position += movement * Time.fixedDeltaTime;
    }
}
