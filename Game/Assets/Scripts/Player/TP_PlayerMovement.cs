using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_PlayerMovement : MonoBehaviour
{
    //private CharacterController _characterController;

    //[Header("Player Options")]
    //[SerializeField] float plrSpeed = 2.0f;
    //[SerializeField] private float plrJumpHeight = 1.0f;
    //[SerializeField] private float plrGravityStrength = -9.81f;
    
    //[Header("Player States (do not modify)")]
    //[SerializeField] private Vector3 plrVelocity;
    //[SerializeField] private bool plrGrounded;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * (Time.deltaTime * playerSpeed));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
