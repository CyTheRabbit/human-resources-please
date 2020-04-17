using System;
using UnityEngine;

namespace Quests
{
    public abstract class BaseCondition : MonoBehaviour, ICondition
    {
        private enum ConditionType
        {
            Pass,
            Fail
        }


        [SerializeField] private ConditionType m_type = ConditionType.Pass;


        protected Action Refresh = delegate {};


        public bool Passed => Done && m_type == ConditionType.Pass;
        public bool Failed => Done && m_type == ConditionType.Fail;


        protected abstract bool Done { get; }


        public virtual void Init(Action refreshAction)
        {
            Refresh = refreshAction;
        }

        public virtual void Stop()
        {
        }
    }
}