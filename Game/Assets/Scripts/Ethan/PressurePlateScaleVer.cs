using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScaleVer : MonoBehaviour
{
    public RaiseObjectScale interactable;

    private void OnTriggerEnter(Collider other)
    {
        interactable.raising = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interactable.raising = false;
    }
}
