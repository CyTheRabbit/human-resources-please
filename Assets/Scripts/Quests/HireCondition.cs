using System;
using Character;
using UnityEngine;

namespace Quests
{
    public class HireCondition : BaseCondition
    {
        [SerializeField] private JobPosition m_trackedJob = null;
        [SerializeField] private int m_requiredCount = 1;


        private Action refreshAction = null;
        private int employeeCount = 0;


        protected override bool Done => employeeCount >= m_requiredCount;


        private void Increment()
        {
            employeeCount++;
            if (Passed) refreshAction();
        }

        
        public override void Init(Action refresh)
        {
            refreshAction = refresh;
            employeeCount = 0;
            m_trackedJob.Hired += Increment;
        }

        public override void Stop()
        {
            m_trackedJob.Hired -= Increment;
        }
    }
}