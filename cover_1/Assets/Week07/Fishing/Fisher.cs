using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{
    // Overall sequence
    Coroutine sequence;

    // Casting variables
    public Transform rotateHandle;
    public Vector3 rotateDirection;
    public float castBackDegree = -30;
    public float castOutDegree = 30;
    public float castDuration = 1f;

    // Bobber/hook variables
    public Transform bobberHandle;
    public Vector3 bobberDirection = Vector3.forward;
    public float bobberMinDistance = 1;
    public float bobberMaxDistance = 10f;

    public float bobDuration;
    public float bobActionDuration;
    public int minBobs = 1;
    public int maxBobs = 4;

    public float bobActionHeightOffset = -1f;

    public enum BobbingResult
    {
        None,
        Catch,
        Miss
    }

    public BobbingResult result;

    // Catch variables
    public Transform endOfPoleHandle;
    public float catchDuration = 1;

    // Line renderer
    public LineRenderer lineRenderer;


    void Update()
    {
        if (sequence == null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                sequence = StartCoroutine(ExecuteSequence());
            }
        }

        lineRenderer.SetPosition(0, endOfPoleHandle.position);
        lineRenderer.SetPosition(1, bobberHandle.position);
    }

    IEnumerator ExecuteSequence()
    {
        yield return StartCoroutine(ExecuteCast());
        yield return StartCoroutine(ExecuteBobbing());

        switch (result)
        {
            case BobbingResult.Catch:
                yield return StartCoroutine(ExecuteCatch());
                break;

            case BobbingResult.None:
            case BobbingResult.Miss:
                yield return StartCoroutine(ExecuteMiss());
                break;
        }

        sequence = null;
    }

    IEnumerator ExecuteCast()
    {
        float castTimer = 0;
        while (castTimer < castDuration)
        {
            // Turn the timer into a vaklue between 0 and 1
            float interp = castTimer / castDuration;

            // Update the degree / rotation
            float degree = Mathf.Lerp(castBackDegree, castOutDegree, interp);
            rotateHandle.localRotation = Quaternion.Euler(rotateDirection * degree);

            // Update the distance
            float bobberDistance = Mathf.Lerp(bobberMinDistance, bobberMaxDistance, interp);
            bobberHandle.localPosition = bobberDirection * bobberDistance;

            yield return null;
            castTimer += Time.deltaTime;
        }
    }

    IEnumerator ExecuteBobbing()
    {
        result = BobbingResult.None;

        // Decide how many bobs to do
        int bobCount = Random.Range(minBobs, maxBobs);
        for (int i = 0; i < bobCount; i++)
        {
            yield return StartCoroutine(ExecuteSingleBob());

            // If we have a valid result, stop doing bobs
            if (result != BobbingResult.None)
            {
                break;
            }
        }

        yield return null;
    }

    IEnumerator ExecuteSingleBob()
    {
        // Play each bob sequence
        float bobTimer = 0;
        while (bobTimer < bobDuration)
        {
            // If the timer is less than the action duration, it's a good catch
            bool canCatch = false;
            if (bobTimer < bobActionDuration)
            {
                canCatch = true;
            }

            // Good catches go underwater
            Vector3 currentPosition = bobberHandle.localPosition;
            if (canCatch)
            {
                currentPosition.y = bobActionHeightOffset;
            }
            // Bad catches stay on the surface
            else
            {
                currentPosition.y = 0;
            }
            bobberHandle.localPosition = currentPosition;

            // Decide if players inputted
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canCatch)
                {
                    result = BobbingResult.Catch;
                    break;
                }
                else
                {
                    result = BobbingResult.Miss;
                    break;
                }
            }

            yield return null;
            bobTimer += Time.deltaTime;
        }
    }

    IEnumerator ExecuteCatch()
    {
        Vector3 catchPosition = bobberHandle.position;
        Vector3 endOfPolePosition = endOfPoleHandle.position;

        float catchTimer = 0;
        while (catchTimer < catchDuration)
        {
            // Turn the timer into a vaklue between 0 and 1
            float interp = catchTimer / catchDuration;

            // Move from the catch point to the end of the pole
            Vector3 position = Vector3.Lerp(catchPosition, endOfPolePosition, interp);
            bobberHandle.position = position;

            yield return null;
            catchTimer += Time.deltaTime;
        }
    }

    IEnumerator ExecuteMiss()
    {
        // Go back to the starting point
        bobberHandle.localPosition = Vector3.zero;

        yield return null;
    }
}
