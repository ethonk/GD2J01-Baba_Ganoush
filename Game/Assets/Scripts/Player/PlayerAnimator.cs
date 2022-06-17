using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMovement plrMovement;
    [SerializeField] private Animator plrAnimator;

    private void Start()
    {
        plrAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isWalking = false;
        if (plrMovement.lastPosition == plrMovement.transform.position)
            isWalking = false;
        else
            isWalking = true;

        bool isLimping;
        if (plrMovement.playerSpeed == plrMovement.defaultPlayerSpeed)
            isLimping = false;
        else
            isLimping = true;
        
        plrAnimator.SetBool("walking", isWalking);
        plrAnimator.SetBool("limping", isLimping);
    }
}
