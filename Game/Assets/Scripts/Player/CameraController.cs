using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float RotationSpeed = 1.0f;

    [Header("Player References")]
    [SerializeField] private Transform Target, Player;
    private float MouseX, MouseY;

    private void Start()
    {
        // Hide cursor visibility.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate() 
    {
        CameraControl();
    }

    void CameraControl()
    {
        // Acquire input
        MouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        MouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        // Clamp MouseY
        MouseY = Mathf.Clamp(MouseY, -35.0f, 35.0f);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(MouseY, MouseX, 0);
        Player.rotation = Quaternion.Euler(0, MouseX, 0);
    }
}
