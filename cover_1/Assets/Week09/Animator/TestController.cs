using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public Animator animator;

    public string BounceTriggerName = "GoBounce";
    public string SquishBoolName = "IsSquish";

    public float dummyValue = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool(SquishBoolName, true);        
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool(SquishBoolName, false);
        }
    }
}
