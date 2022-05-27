//
// Bachelor of Software Engineering
// Media Design School
// Auckland
// New Zealand
//
// (c) Media Design School
//
// File Name : EventManager.cs
// Description : Global Event Manager. Runs functions that are subscribed through the invoke.
// Author : Ethan Uy
// Mail : ethan.uy@mds.ac.nz
//

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Managers.EventManagement
{
    public class EventManagement : MonoBehaviour
    {
        // To start dialogue.
        [System.Serializable]
        public class DialogueStartEvent : UnityEvent<string, string[]>{}
        public DialogueStartEvent onStartDialogue;
        
        public void SetDialogueSentences(string dialogueName, string[] dialogueSentences)
        {
            // Invoke the dialogue manager.
            onStartDialogue.Invoke(dialogueName, dialogueSentences);
        }
    }
}