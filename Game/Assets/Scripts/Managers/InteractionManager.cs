using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("General")] 
    [SerializeField] private string entityName;
    
    private enum InteractionTypes { Dialogue, Special, Pickup };
    [Header("Interaction Type")]
    [SerializeField] private InteractionTypes interactionType;
    
    [Header("Interaction Settings")]
    [SerializeField] private float interactionRange;

    [Header("Interact UI")] 
    [SerializeField] private GameObject interactionUI;

    private Transform _player;
    public bool currentlyInteracting = false;

    // Start is called before the first frame update
    private void Start()
    {
        _player = GameObject.Find("Player").transform;   // find the player.
    }
    
    // Update is called once per frame
    private void Update()
    {
        // Configure Interaction UI visibility.
        SetInteractionUI();
        // Rotate towards the player.
        RotateUIToPlayer();
        
        if (Input.GetKeyDown(KeyCode.E) && IsInteractable())
        {
            currentlyInteracting = true;

            switch (interactionType)
            {
                case InteractionTypes.Dialogue:
                    print("start dialogue");
                    break;
            }
            
        }
    }

    bool IsInteractable()
    {
        if (IsWithinDistance() && !currentlyInteracting)
            return true;
        return false;
    }
    
    bool IsWithinDistance()
    {
        if (Vector3.Distance(_player.position, transform.position) <= interactionRange)
            return true;
        return false;
    }
    
    void SetInteractionUI()
    {
        if (IsInteractable())
            interactionUI.SetActive(true);
        else
            interactionUI.SetActive(false);
    }

    void RotateUIToPlayer()
    {
        var LookDirection = _player.position - interactionUI.transform.position;
        LookDirection.x *= -1;
        LookDirection.y = 0;
        LookDirection.z *= -1;

        interactionUI.transform.rotation = Quaternion.LookRotation(LookDirection);
    }
}
