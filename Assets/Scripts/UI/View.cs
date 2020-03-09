using UnityEngine;

namespace UI
{
    /// <summary>
    /// Abstract class for any prefab that 
    /// </summary>
    /// <typeparam name="TModel">Type of data the class used to display</typeparam>
    [RequireComponent(typeof(RectTransform))]
    public abstract class View<TModel> : MonoBehaviour
    {
        protected TModel Model;

        protected bool Visible
        {
            get => gameObject.activeSelf;
            set => gameObject.SetActive(value);
        }

        public virtual void Init(TModel model) => Model = model;

        public virtual void Show() {}

        public virtual void Hide() {}

        public virtual void Refresh() {}
    }
}
