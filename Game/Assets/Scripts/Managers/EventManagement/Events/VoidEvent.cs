using UnityEngine;

namespace EventManagement.Events
{
    [CreateAssetMenu(fileName = "New Void Event", menuName = "Game Events/Void Event")]
    public class VoidEvent : BaseGameEvent<Void>
    {
        // Once again, while it returns nothing it still needs a parameter.
        // Therefore we pass void, a custom type we made with no properties.
        public void Raise() => Raise(new Void());
    }    
}