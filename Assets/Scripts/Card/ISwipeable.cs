using UnityEngine.EventSystems;

namespace Card
{
    public interface ISwipable : IEventSystemHandler
    {
        void SwipeLeft();
        void SwipeRight();
        void Reveal();
        void SwipeStart();
    }
}