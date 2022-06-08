using System;
using System.Collections;
using System.Collections.Generic;
using Managers.EventManagement;
using UnityEngine;

[System.Serializable]
public class DialogueTextClass
{
    public string[] Dialogues;
}
public class CutsceneCreator : MonoBehaviour
{
    // Dialogue and Cameras
    [TextArea]
    public string Notes1 = "IMPORTANT: DialogueNames and Dialogues must have the same number of elements.";
    [Space(10)]
    public List<string> DialogueNames;
    public List<DialogueTextClass> Dialogues = new List<DialogueTextClass>();
    public List<Camera> Cameras;

    [TextArea]
    public string Notes2 = "IMPORTANT: UseDialogue and UseCamera must have the same number of elements.";
    [Space(10)]
    // Dialogue switch and cameras.
    public List<bool> UseDialogue;
    public List<bool> UseCamera;

    // Running Events
    private EventManagement _eventManagement;
    private Camera mainCamera;
    private Camera currentCamera;

    private int index = 0;
    private void Start()
    {
        // Define core.
        _eventManagement = GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>();
        mainCamera = Camera.main;
        
        DoCutscene();
    }

    public void DoCutscene()
    {
        // == START ==
        if (mainCamera != null) mainCamera.enabled = false; // disable the main camera

        if (UseDialogue[index]) 
            _eventManagement.SetDialogueSentences(DialogueNames[index], Dialogues[index].Dialogues);

        if (UseCamera[index])
        {
            if (currentCamera != null) currentCamera.enabled = false;
            currentCamera = Cameras[index];
            currentCamera.enabled = true;
        }

        index++; // increase the index.
        if (index > UseDialogue.Count - 1)
            EndCutscene();
    }
    
    private void EndCutscene()
    {
        mainCamera.enabled = true;
        index = 0;
    }
}
