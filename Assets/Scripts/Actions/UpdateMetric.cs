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
            Debug.Log($"Changed \"{m_metric.name}\" metric ({m_metric.Value:F2} -> {m_metric.Value + m_value:F2})");
            m_metric.Value += m_value;
        }
    }
}