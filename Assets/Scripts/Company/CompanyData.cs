using System.Collections.Generic;
using Character;
using UnityEngine;

namespace Company
{
    [CreateAssetMenu(menuName = "Data/Company")]
    public class CompanyData : ScriptableObject
    {
        private CompanyConfig config = null;
        private EventManager events = null;
        
        private readonly List<MetricData> metrics = new List<MetricData>();


        public List<MetricData> Metrics => metrics;


        private void OnHireUpdateMetrics(CharacterData character)
        {
            MetricData data = metrics.Find(m => m.Config.m_name == character.m_metric_name);
            data.Value += character.m_metric_change;
        }
        
            
        public void Init(CompanyConfig companyConfig, EventManager eventManager)
        {
            config = companyConfig;
            events = eventManager;

            foreach (MetricConfig metricConfig in config.m_metrics)
            {
                MetricData data = CreateInstance<MetricData>();
                data.Init(metricConfig, eventManager);
                metrics.Add(data);
            }

            events.CharacterHired += OnHireUpdateMetrics;
        }
    }
}