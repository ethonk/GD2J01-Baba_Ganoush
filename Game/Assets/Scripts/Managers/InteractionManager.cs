using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public enum InteractionTypes { Dialogue, Special };
    [Header("Interaction Type")]
    [SerializeField] private InteractionTypes interactionType;
    
    [Header("Interaction Settings")]
    [SerializeField] private float interactionRange;

    private Transform player;
    public bool currentlyInteracting = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;   // find the player.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Vector3.Distance(player.position, transform.position) <= interactionRange && !currentlyInteracting)
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
}
