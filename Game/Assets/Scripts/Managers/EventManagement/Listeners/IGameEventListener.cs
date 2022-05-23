namespace EventManagement.Events
{
    public interface IGameEventListener<T>
    {
        // Anything that is an event listener has a function to raise it. That takes in the same type as the listener.
        void OnEventRaised(T item);
    }
}