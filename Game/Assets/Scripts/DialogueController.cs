using System;
using System.Collections;
using System.Collections.Generic;
using Managers.EventManagement;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI dialogueNameComponent;
    [SerializeField] private TextMeshProUGUI dialogueTextComponent;

    [Header("Dialogue Settings")] 
    [SerializeField] private float talkSpeed;

    [SerializeField] private string dialogueName;
    [SerializeField] private string[] dialogueSentences;

    public int talkIndex;
    
    // event manager
    private EventManagement _eventManagement;

    private void Start()
    {
        _eventManagement = GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueTextComponent.text == dialogueSentences[talkIndex])
            {
                NextSentence();
            }
        }
    }

    public void StartDialogue(string givenName, string[] givenSentences)
    {
        // Enable the dialogue controller.
        ExitDialogue();                     // first exit: to ensure dialogue does not overwrite existing
        EnableDialogueController(true);     // second enter: start dialogue.
        
        // Set the text of the dialogue.
        dialogueName = givenName;
        dialogueSentences = givenSentences;
        
        // Set dialogue components to null.
        dialogueNameComponent.text = dialogueName;
        dialogueTextComponent.text = string.Empty;
        
        talkIndex = 0;                          // set index to '0' to indicate start of conversation.
        StartCoroutine(TypeSentence());   // start typing the line.
    }

    private void ExitDialogue()
    {
        // stop the dialogue controller.
        EnableDialogueController(false);
        StopAllCoroutines();
    }

    IEnumerator TypeSentence()
    {
        // Type each character in the given sentence one by one.
        foreach (char c in dialogueSentences[talkIndex].ToCharArray())
        {
            dialogueTextComponent.text += c;            // and character to text string.
            yield return new WaitForSeconds(talkSpeed); // wait (x)ms before typing again.
        }
    }

    void NextSentence()
    {
        if (talkIndex < dialogueSentences.Length - 1)
        {
            talkIndex++;
            dialogueTextComponent.text = string.Empty;
            StartCoroutine(TypeSentence());
        }
        else
        {
            ExitDialogue();
            
            // tell the event manager that cutscene is finished.
            _eventManagement.FinishedDialogue();
        }
    }

    void EnableDialogueController(bool enable)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(enable);
        }
    }
}
