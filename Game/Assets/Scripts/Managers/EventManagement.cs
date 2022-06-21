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
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Managers.EventManagement
{
    public class EventManagement : MonoBehaviour
    {
        // Global variables
        //
        // Currency
        public int _coinCount = 0;
        // Player status
        public float debuffTime = 3.0f;
        public bool isDebuffed = false;

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
            // before invoking, check if there are any null listeners (removed)
            for (int i = 0; i < onDialogueFinish.GetPersistentEventCount(); i++)
                if (onDialogueFinish.GetPersistentTarget(i) != null)
                    break;
            
            // if none, invoke.
            onDialogueFinish.Invoke();
        }
        
        // enable event
        [System.Serializable]
        public class DebuffApplyEvent : UnityEvent{}
        public DebuffApplyEvent onDebuffApply;
        [System.Serializable]
        public class DebuffSpeedApplyEvent : UnityEvent{}
        public DebuffSpeedApplyEvent onDebuffSpeedApply;
        public void SpeedDebuffApplied()
        {
            onDebuffSpeedApply.Invoke();
        }
        // disable event
        [System.Serializable]
        public class DebuffExpelEvent : UnityEvent{}
        public DebuffExpelEvent onDebuffExpel;
        public void StartDebuff()
        {
            isDebuffed = true;
            StartCoroutine(StopAllDebuffs());
        }

        public void ApplyDebuffVision()
        {
            onDebuffApply.Invoke();
        }
        // DEBUFF COROUTINE
        private IEnumerator StopAllDebuffs()
        {
            yield return new WaitForSeconds(debuffTime);
            isDebuffed = false;
            onDebuffExpel.Invoke();
            
            print("run it back!");
        }
    }
}