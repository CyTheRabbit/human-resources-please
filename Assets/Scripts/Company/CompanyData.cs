using UnityEngine;

namespace Company
{
    [CreateAssetMenu(menuName = "Data/Company")]
    public class CompanyData : ScriptableObject
    {
        [SerializeField] private MetricData[] m_metrics = null;
        [SerializeField] private CompanyEvents m_events = null;


        public MetricData[] Metrics => m_metrics;


        public void Init()
        {
        }
    }
}