using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    public Transform focusObject;
    public bool flipped;

    void Update()
    {
        var lookDirection = focusObject.position - transform.position;
        lookDirection.x *= -1;
        lookDirection.y = 0;
        lookDirection.z *= -1;

        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
