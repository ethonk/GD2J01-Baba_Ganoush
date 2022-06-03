using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWMoveManager : MonoBehaviour
{
    //Reference to BWEnterTrigger Script
    public BWEnterTrigger enterTrigger;

    [Header("Settings")]
    [SerializeField] public float m_speed = 2.0f;

    [Header("Target Position")]
    [SerializeField] private float xAxis = 0;
    [SerializeField] private float yAxis = 0;
    [SerializeField] private float zAxis = 0;

    //Rigidbody m_Rigidbody;

    private void start()
    {
        //Position of object at its original point.
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

    }
 

    void Update()
    {
        if (GameObject.Find("ActivationZone").GetComponent<BWEnterTrigger>().check)     //This GameObject find ("") name has to be where the zone or area that the player walks into to activate it. ||Could have it find via tag?
        {
            Vector3 targetPosition = new Vector3(xAxis, yAxis, zAxis);
            transform.position += transform.forward * Time.deltaTime;

            
            // Move our position a step closer to the target.
            var step = m_speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.Lerp(transform.position, targetPosition, step);
            
            
        }
         
    }
    
}