using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float MoveSpeed = 10.0f;
    [SerializeField] private float JumpForce = 10.0f;

    // Ground Checking
    float DistanceToGround;

    private void Start() 
    {
        // Get starting ground distance
        DistanceToGround = GetComponent<CapsuleCollider>().bounds.extents.y;    
    }
    private void Update() 
    {
        // Movement
        PlayerMovement();

        // Forces
        Jump();
    }

    void PlayerMovement()
    {
        // Acquire input from the player
        float InputHori = Input.GetAxis("Horizontal");
        float InputVert = Input.GetAxis("Vertical");

        // Translate the player
        Vector3 PlayerMovement = new Vector3(InputHori, 0.0f, InputVert) * MoveSpeed * Time.deltaTime;
        transform.Translate(PlayerMovement, Space.Self);
    }  

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, JumpForce, 0.0f), ForceMode.Impulse);
        }
    }  

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.1f);
    }
}
