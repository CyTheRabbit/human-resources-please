using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterGenerator : ScriptableObject
    {
        private GeneratorConfig config = null;

        
        private static T SelectRandom<T>(IReadOnlyList<T> array)
        {
            return array[Random.Range(0, array.Count)];
        }
        

        public void Init(GeneratorConfig generatorConfig)
        {
            config = generatorConfig;
        }

        public CharacterData Generate()
        {
            GeneratorConfig.MetricChange change = SelectRandom(config.m_changes);
            return new CharacterData
            {
                m_name = SelectRandom(config.m_names),
                m_description = SelectRandom(config.m_descriptions),
                m_metric_name = change.m_config.m_name,
                m_metric_change = change.m_valueChange
            };
        }
    }
}