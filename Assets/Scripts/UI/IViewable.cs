using UnityEngine.EventSystems;

namespace UI
{
    public interface IViewable : IEventSystemHandler
    {
        void Show();
        void Hide();
        void Refresh();
    }
}