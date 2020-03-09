using UnityEngine;

namespace Company
{
    [CreateAssetMenu(menuName = "Configs/Metric")]
    public class MetricConfig : ScriptableObject
    {
        public string m_name = null;
        public Color m_color = Color.white;
        [Range(0, 1)] public float m_defaultValue = 0.5f;
    }
}