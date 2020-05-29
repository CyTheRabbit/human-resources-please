using System;
using UnityEngine;

namespace Quests
{
    [AddComponentMenu("Quest Conditions/Quest Completion Condition")]
    public class QuestCompletionCondition : BaseCondition
    {
        [SerializeField] private EventManager m_events = null;
        [Space]
        [SerializeField] private int m_total = 0;


        private int counter = 0;


        protected override bool Done => counter >= m_total;


        private void Count()
        {
            counter++;
            if (Passed) Refresh();
        }


        public override void Init(Action refreshAction)
        {
            base.Init(refreshAction);
            counter = 0;
            m_events.Company.QuestCompleted += Count;
        }

        public override void Stop()
        {
            m_events.Company.QuestCompleted -= Count;
        }
    }
}