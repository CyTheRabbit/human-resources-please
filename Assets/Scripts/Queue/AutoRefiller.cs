using Filler;
using UnityEngine;

namespace Queue
{
    public class AutoRefiller : MonoBehaviour
    {
        [SerializeField] private EventManager m_events = null;
        [SerializeField] private FillerGenerator m_filler = null;
        [SerializeField] private int m_refillCount = 10;

        private void Start()
        {
            m_events.Queue.QueueEmptied += Refill;
        }

        private void Refill()
        {
            m_filler.Generate(m_refillCount);
        }
    }
}