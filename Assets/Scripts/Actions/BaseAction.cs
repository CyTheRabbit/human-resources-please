using Card;
using Quests;
using UnityEngine;

namespace Actions
{
    public abstract class BaseAction : MonoBehaviour, ISwipable, IOutcome
    {
        private enum TriggerEvent
        {
            None,

            Hire,
            Skip,
            AnySwipe,

            PrepareQuest,
            StopQuest,
            PassQuest,
            FailQuest
        }

        [SerializeField] private TriggerEvent m_trigger = TriggerEvent.None;

        protected abstract void Act();

        #region Event Handlers
        
        public void SwipeLeft()
        {
            if (m_trigger == TriggerEvent.Skip 
                || m_trigger == TriggerEvent.AnySwipe) Act();
        }

        public void SwipeRight()
        {
            if (m_trigger == TriggerEvent.Hire
                || m_trigger == TriggerEvent.AnySwipe) Act();
        }

        public void Pass()
        {
            if (m_trigger == TriggerEvent.PassQuest) Act();
        }

        public void Fail()
        {
            if (m_trigger == TriggerEvent.FailQuest) Act();
        }

        public void Prepare()
        {
            if (m_trigger == TriggerEvent.PrepareQuest) Act();
        }

        public void Stop()
        {
            if (m_trigger == TriggerEvent.StopQuest) Act();
        }


        #endregion
    }
}