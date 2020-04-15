using System;
using UnityEngine;

namespace Company
{
    [CreateAssetMenu(menuName = "Data/Company Metric")]
    public class MetricData : ScriptableObject
    {
        public event Action Changed = null;


        [SerializeField] private MetricConfig m_config = null;
        [SerializeField] private CompanyEvents m_events = null;
        
        private float currentValue = 1.0f;


        public MetricConfig Config => m_config;
        
        public float Value
        {
            get => currentValue;
            set
            {
                currentValue = Mathf.Clamp01(value);
                Changed?.Invoke();
                m_events.OnMetricChanged();
                if (currentValue <= 0.0f) m_events.OnMetricEmptied();
            }
        }

        public void Init()
        {
            currentValue = m_config.m_defaultValue;
        }
    }
}