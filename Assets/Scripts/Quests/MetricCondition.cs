using System;
using Company;
using UnityEngine;

namespace Quests
{
    public class MetricCondition : BaseCondition
    {

        private enum ComparisonType
        {
            LessOrEqual,
            GreaterOrEqual
        }

        [SerializeField] private MetricData m_metric = null;
        [SerializeField] private float m_threshold = 0f;
        [SerializeField] private ComparisonType m_comparison = ComparisonType.LessOrEqual;


        protected override bool Done =>
            (m_comparison == ComparisonType.LessOrEqual && m_metric.Value <= m_threshold)
            || (m_comparison == ComparisonType.GreaterOrEqual && m_metric.Value >= m_threshold);

        
        private void Test()
        {
            if (Done) Refresh();
        }
        

        public override void Init(Action refreshAction)
        {
            base.Init(refreshAction);
            m_metric.Changed += Test;
        }

        public override void Stop()
        {
            m_metric.Changed -= Test;
        }
    }
}