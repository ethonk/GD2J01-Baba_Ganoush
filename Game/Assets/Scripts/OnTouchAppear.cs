using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchAppear : MonoBehaviour
{
    public bool alreadyTriggered = false;
    
    public GameObject target;
    public bool appear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !alreadyTriggered)
        {
            alreadyTriggered = true;

            target.GetComponent<BoxCollider>().enabled = appear;
            target.GetComponent<MeshRenderer>().enabled = appear;
        }
    }
}
