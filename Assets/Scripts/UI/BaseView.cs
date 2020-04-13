using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class BaseView : MonoBehaviour, IViewable
    {
        protected bool Visible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }


        public virtual void Show()
        {
        }

        public virtual void Hide()
        {
        }

        public virtual void Refresh()
        {
        }


        public static void ShowEvent(IViewable view, BaseEventData _) => view.Show();
        public static void HideEvent(IViewable view, BaseEventData _) => view.Hide();
        public static void RefreshEvent(IViewable view, BaseEventData _) => view.Refresh();
    }
}