using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float rotationSpeed = 1.0f;
    [SerializeField] private float xMaxLook;
    [SerializeField] private float yMaxLook;
    [SerializeField] private float distance = 10.0f;
    [SerializeField] private float xCurrent, yCurrent;
    [SerializeField] private float sensitivity;
    
    [Header("Player References")]
    [SerializeField] private Transform player, targetLookAt;

    private void LateUpdate()
    {
        xCurrent += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        yCurrent += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        yCurrent = Mathf.Clamp(yCurrent, -yMaxLook, yMaxLook);

        Vector3 camDirection = new Vector3(0, 0, -distance);
        Quaternion camRotation = Quaternion.Euler(yCurrent, xCurrent, 0);
        transform.position = targetLookAt.position + camRotation * camDirection;
        
        transform.LookAt(targetLookAt.position);
        
        // rotate player with camera
    }
}
