using System;
using UnityEngine;

namespace Company
{
    [CreateAssetMenu(fileName = "Company Events", menuName = "Events/Company", order = 0)]
    public class CompanyEvents : ScriptableObject
    {
        public event Action MetricChanged = null;
        public event Action MetricEmptied = null;

        public void OnMetricChanged()
        {
            MetricChanged?.Invoke();
        }

        public void OnMetricEmptied()
        {
            MetricEmptied?.Invoke();
        }
    }
}