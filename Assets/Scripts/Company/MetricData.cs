using UnityEngine;

namespace Company
{
    [CreateAssetMenu(menuName = "Data/Company Metric")]
    public class MetricData : ScriptableObject
    {
        private MetricConfig config = null;
        private EventManager events = null;
        private float currentValue = 1.0f;


        public MetricConfig Config => config;
        
        public float Value
        {
            get => currentValue;
            set
            {
                currentValue = Mathf.Clamp01(value);
                events.MetricChanged?.Invoke(config.m_name, currentValue);
                if (currentValue <= 0.0f) events.MetricEnded?.Invoke(config.m_name);
            }
        }

        public void Init(MetricConfig metricConfig, EventManager eventManager)
        {
            config = metricConfig;
            events = eventManager;

            currentValue = config.m_defaultValue;
        }
    }
}