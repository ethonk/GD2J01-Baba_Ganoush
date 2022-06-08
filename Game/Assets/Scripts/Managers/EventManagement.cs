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
        // Global variables
        private int _coinCount = 0;

        // To start dialogue.
        [System.Serializable]
        public class DialogueStartEvent : UnityEvent<string, string[]> {}
        public DialogueStartEvent onStartDialogue;
        public void SetDialogueSentences(string dialogueName, string[] dialogueSentences)
        {
            // Invoke the dialogue manager.
            onStartDialogue.Invoke(dialogueName, dialogueSentences);
        }
        
        [System.Serializable]
        public class CoinAddEvent : UnityEvent<int, int> {}
        public CoinAddEvent onCoinAdd;
        public void AddCoins()
        {
            _coinCount++; // add coin.
            // Invoke the add coin.
            onCoinAdd.Invoke(_coinCount, 0);
        }
        
        [System.Serializable]
        public class DialogueFinishedEvent : UnityEvent{}
        public DialogueFinishedEvent onDialogueFinish;
        public void FinishedDialogue()
        {
            if (onDialogueFinish != null) onDialogueFinish.Invoke();
        }
    }
}