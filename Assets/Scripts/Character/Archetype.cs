using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Configs/Archetype", order = 0)]
    public class Archetype : ScriptableObject
    {
        public string[] m_names = null;
        [TextArea] public string[] m_descriptions = null;
        public GeneratorConfig.MetricChange[] m_metrics = null;

        
        private static T SelectRandom<T>(IReadOnlyList<T> array)
        {
            return array[Random.Range(0, array.Count)];
        }

        
        public CharacterData Generate()
        {
            CharacterData data = new CharacterData();
            if (m_names?.Length > 0) data.m_name = SelectRandom(m_names);
            if (m_descriptions?.Length > 0) data.m_description = SelectRandom(m_descriptions);
            if (m_metrics?.Length > 0)
            {
                GeneratorConfig.MetricChange metric = SelectRandom(m_metrics);
                data.m_metric_name = metric.m_config.m_name;
                data.m_metric_change = metric.m_valueChange;
            }
            return data;
        }
    }
}