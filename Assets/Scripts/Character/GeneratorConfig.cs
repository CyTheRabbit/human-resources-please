using System;
using Company;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Configs/Character Generator")]
    public class GeneratorConfig : ScriptableObject
    {
        [Serializable]
        public class MetricChange
        {
            public MetricConfig m_config = null;
            [Range(-1, 1)] public float m_valueChange = 0;
        }

        public string[] m_names = null;
        [TextArea] public string[] m_descriptions = null;
        public MetricChange[] m_changes = null;

    }
}