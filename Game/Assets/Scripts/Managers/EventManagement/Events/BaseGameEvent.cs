using System.Collections.Generic;
using UnityEngine;

namespace EventManagement.Events
{
    // Templatized
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        // A list of all the game event listeners.
        private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

        // Invoking the event.
        public void Raise(T item)
        {
            // Backwards loop, as an event may destroy an object when being raised.
            for (int i = eventListeners.Count - 1; i >= 0 ; i--)
            {
                // Tell all our listeners the event was raised with given data.
                eventListeners[i].OnEventRaised(item);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            // Only register it ONCE.
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            // If exists, remove it.
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }
    }   
}