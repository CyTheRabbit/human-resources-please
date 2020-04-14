using Company;
using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Update Metrics")]
    public class UpdateMetric : BaseAction
    {
        private const float Recommended_Range = 0.5f;
        
        
        [SerializeField] private MetricData m_metric = null;
        [Range(-Recommended_Range, Recommended_Range)] 
        [SerializeField] private float m_value = 0;


        protected override void Act()
        {
            m_metric.Value += m_value;
        }
    }
}