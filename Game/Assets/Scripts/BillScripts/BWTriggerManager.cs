using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWTriggerManager : MonoBehaviour
{
    // Making BWEnterTrigger a public script to this script to access the bool
    public BWEnterTrigger EnterTrigger;

    [Header("Settings")]
    [SerializeField] public float speed = 10.0f;
    [SerializeField] private float xAxis = 0;
    [SerializeField] private float yAxis = 0;
    [SerializeField] private float zAxis = 0;

    private void Start()
    {
        
    }

    public void ObjMoveScript()
    {
        transform.Translate(xAxis, yAxis, zAxis, Space.World);


    }

}
