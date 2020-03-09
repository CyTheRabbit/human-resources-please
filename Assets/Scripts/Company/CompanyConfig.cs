using UnityEngine;

namespace Company
{
    [CreateAssetMenu(menuName = "Configs/Company")]
    public class CompanyConfig : ScriptableObject
    {
        public MetricConfig[] m_metrics = null;
    }
}