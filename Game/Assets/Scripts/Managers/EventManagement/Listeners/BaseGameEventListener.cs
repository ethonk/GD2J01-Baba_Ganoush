using UnityEngine;
using UnityEngine.Events;

namespace EventManagement.Events
{
    // <T, E, UER> = <Type, Event, Unity Event Response>
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, 
        IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T> // Interface. For every event there are three different types.
    {
        // E = same type of game event we are listening for
        [SerializeField] private E gameEvent;
        public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

        [SerializeField] private UER unityEventResponse;

        // Listen only when existing in scene.
        private void OnEnable()
        {
            if (gameEvent == null) { return; }  // Don't crash if event is null.

            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null) { return; }  // Don't crash if event is null.

            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (unityEventResponse != null) // if a response is given
            {
                unityEventResponse.Invoke(item);
            }
        }
    }
}
