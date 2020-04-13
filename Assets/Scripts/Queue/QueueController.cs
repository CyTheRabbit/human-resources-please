using UnityEngine;

namespace Queue
{
    public class QueueController : MonoBehaviour
    {
        [SerializeField] private EventManager m_events = null;
        [SerializeField] private DataManager m_data = null;


        private void OnCardRemoved()
        {
            GameObject nextCard = transform.GetChild(0).gameObject;
            if (transform.childCount == 0)
            {
                m_events.Queue.OnQueueEmptied();
            }

            m_data.CurrentCard = nextCard;
        }


        public void Init()
        {
            m_events.Queue.CardRemoved += OnCardRemoved;
        }
    }
}