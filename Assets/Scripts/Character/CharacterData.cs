using System;

namespace Character
{
    [Serializable]
    public class CharacterData
    {
        public string m_name = null;
        public string m_description = null;

        public string m_metric_name = null;
        public float m_metric_change = 0;
    }
}