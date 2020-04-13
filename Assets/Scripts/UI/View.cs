using UnityEngine;

namespace UI
{
    /// <summary>
    /// Abstract class for any prefab that 
    /// </summary>
    /// <typeparam name="TModel">Type of data the class used to display</typeparam>
    [RequireComponent(typeof(RectTransform))]
    public abstract class View<TModel> : BaseView
    {
        protected TModel Model;

        public virtual void Init(TModel model) => Model = model;
    }
}
