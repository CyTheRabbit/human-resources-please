using System;
using Character;
using UnityEngine;

namespace Quests
{
    public class HireCondition : MonoBehaviour, ICondition
    {
        private enum ConditionType
        {
            Pass,
            Fail
        }
        
        [SerializeField] private ConditionType m_type = ConditionType.Pass;
        [SerializeField] private JobPosition m_trackedJob = null;
        [SerializeField] private int m_requiredCount = 1;


        private Action refreshAction = null;
        private int employeeCount = 0;


        private bool ReachedCount => employeeCount >= m_requiredCount;

        public bool Passed => ReachedCount && m_type == ConditionType.Pass;
        public bool Failed => ReachedCount && m_type == ConditionType.Fail;


        private void Increment()
        {
            employeeCount++;
            if (Passed) refreshAction();
        }

        
        public void Init(Action refresh)
        {
            refreshAction = refresh;
            employeeCount = 0;
            m_trackedJob.Hired += Increment;
        }

        public void Stop()
        {
            m_trackedJob.Hired -= Increment;
        }
    }
}