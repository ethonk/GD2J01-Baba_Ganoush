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
        private string[] DialogueSentences;
        // To start dialogue.
        [SerializeField] private UnityEvent eDialogueStart;

        public void AddListener(UnityAction method)
        {
            eDialogueStart.AddListener(method);
        }
        public void RemoveListener(UnityAction method)
        {
            eDialogueStart.RemoveListener(method);
        }
        
        public void SetDialogueSentences(string[] dialogueSentences)
        {
            // Set the dialogue sentences.
            DialogueSentences = dialogueSentences;
            // Invoke the dialogue manager.
            eDialogueStart.Invoke();
        }
    }
}