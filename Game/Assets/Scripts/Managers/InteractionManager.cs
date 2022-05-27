using System;
using System.Collections;
using System.Collections.Generic;
using Managers.EventManagement;
using TMPro;
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

    [Header("Event Manager")] 
    private EventManagement _eventManagement;

    private Transform _player;
    public bool currentlyInteracting = false;
    
    private void Start()
    {
        // Setup Event Manager
        _eventManagement = GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>();
        
        // Setup the player
        _player = GameObject.Find("Player").transform;

        // Set up what the text says.
        var text = interactionUI.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        switch (interactionType)
        {
            case InteractionTypes.Dialogue:
                text.text = "Speak to ";
                break;
            case InteractionTypes.Pickup:
                text.text = "Pick up ";
                break;
            case InteractionTypes.Special:
                text.text = "Power surrounds ";
                break;
        }
        text.text += entityName;
    }
    
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
                    DoDialogue();
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
        return Vector3.Distance(_player.position, transform.position) <= interactionRange;
    }
    
    void SetInteractionUI()
    {
        interactionUI.SetActive(IsInteractable());
    }

    void RotateUIToPlayer()
    {
        var lookDirection = _player.position - interactionUI.transform.position;
        lookDirection.x *= -1;
        lookDirection.y = 0;
        lookDirection.z *= -1;

        interactionUI.transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    void DoDialogue()
    {
        DialogueScript entityDialogueHandler = GetComponent<DialogueScript>();
        _eventManagement.SetDialogueSentences(entityDialogueHandler.dialogueName,
            entityDialogueHandler.dialogueSentences);
    }
}
