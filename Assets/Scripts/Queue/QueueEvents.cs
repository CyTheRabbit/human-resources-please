using System;
using UnityEngine;

namespace Queue
{
    [CreateAssetMenu(menuName = "Events/Queue")]
    public class QueueEvents : ScriptableObject
    {
        public event Action CardSwipedRight = null;
        public event Action CardSwipedLeft = null;
        public event Action BeforeCardChanged = null;
        public event Action CardChanged = null;
        public event Action CardRemoved = null;
        public event Action QueueEmptied = null;

        public void OnCardSwipedLeft()
        {
            CardSwipedLeft?.Invoke();
        }

        public void OnCardSwipedRight()
        {
            CardSwipedRight?.Invoke();
        }

        public void OnBeforeCardChanged()
        {
            BeforeCardChanged?.Invoke();
        }

        public void OnCardChanged()
        {
            CardChanged?.Invoke();
        }

        public void OnCardRemoved()
        {
            CardRemoved?.Invoke();
        }

        public void OnQueueEmptied()
        {
            QueueEmptied?.Invoke();
        }
    }
}