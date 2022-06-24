using System;
using System.Collections;
using System.Collections.Generic;
using Managers.EventManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int cutsceneIndex = 0;
    
    private void Start()
    {
        // Define core.
        _eventManagement = GameObject.Find("EVENT_MANAGER").GetComponent<EventManagement>();
        mainCamera = Camera.main;
    }

    public void StartCutscene()
    {
        // When starting cutscene, add as listener.
        _eventManagement.onDialogueFinish.AddListener(DoCutscene);
        DoCutscene();
    }
    
    public void DoCutscene()
    {
        // == START ==
        if (mainCamera != null) mainCamera.enabled = false; // disable the main camera

        if (cutsceneIndex < UseDialogue.Count)
        {
            if (UseDialogue[cutsceneIndex]) 
                _eventManagement.SetDialogueSentences(DialogueNames[cutsceneIndex], Dialogues[cutsceneIndex].Dialogues);

            if (UseCamera[cutsceneIndex])
            {
                if (currentCamera != null) currentCamera.enabled = false;
                currentCamera = Cameras[cutsceneIndex];
                currentCamera.enabled = true;
            }
        }

        // End the cutscene if this is the last sequence.
        if (cutsceneIndex >= UseDialogue.Count)
            EndCutscene();
        else
            cutsceneIndex++; // increase the index.
    }
    
    private void EndCutscene()
    {
        print("ending dialogue!");
        
        // When ending cutscene, remove listener.
        _eventManagement.onDialogueFinish.RemoveListener(DoCutscene);
        
        // Re-enable main camera.
        currentCamera.enabled = false;
        mainCamera.enabled = true;
        
        // Reset index.
        cutsceneIndex = 0;
        
        // Next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
