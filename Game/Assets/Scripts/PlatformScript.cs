using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print(other.transform.name);
        
        if(other.transform.root.CompareTag("Player"))
            other.transform.root.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
            other.transform.root.SetParent(null);
    }
}
