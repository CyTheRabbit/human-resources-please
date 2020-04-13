using Company;
using UnityEngine;

namespace Card
{
    public class MetricUpdater : MonoBehaviour, ISwipable
    {
        [SerializeField] private MetricData m_metric = null;
        [SerializeField, Range(-1, 1)] private float m_hireValue = 0;
        [SerializeField, Range(-1, 1)] private float m_skipPenalty = 0;


        public void SwipeRight()
        {
            m_metric.Value += m_hireValue;
        }

        public void SwipeLeft()
        {
            m_metric.Value += m_skipPenalty;
        }
    }
}