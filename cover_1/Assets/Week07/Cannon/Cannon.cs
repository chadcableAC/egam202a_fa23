using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform spawnHandle;
    public Cannonball cannonballPrefab;

    public float force;
    public float frequency;

    void Start()
    {
        StartCoroutine(ExecuteLaunches());
    }

    IEnumerator ExecuteLaunches()
    {
        while (true)
        {
            yield return new WaitForSeconds(frequency);

            Cannonball ball = Instantiate(cannonballPrefab);
            ball.transform.position = spawnHandle.position;
            ball.Launch(spawnHandle.up, force);
        }
    }
}
