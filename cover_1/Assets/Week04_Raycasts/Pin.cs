using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public void Hit()
    {
        Destroy(gameObject);
    }
}
