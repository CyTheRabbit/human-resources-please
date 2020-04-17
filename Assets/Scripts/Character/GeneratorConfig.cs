using System;
using System.Collections.Generic;
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

        [SerializeField] private string[] m_names = null;
        
        [SerializeField, TextArea(minLines: 3, maxLines: 7)]
        private string[] m_descriptions = null;


        public IReadOnlyList<string> Names => m_names;
        public IReadOnlyList<string> Descriptions => m_descriptions;
    }
}
