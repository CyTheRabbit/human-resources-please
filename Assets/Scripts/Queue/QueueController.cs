using UnityEngine;

namespace Queue
{
    public class QueueController : MonoBehaviour
    {
        [SerializeField] private EventManager m_events = null;
        [SerializeField] private DataManager m_data = null;


        private void OnEnable()
        {
            m_events.Queue.CardRemoved += OnCardRemoved;
        }

        private void OnDisable()
        {
            m_events.Queue.CardRemoved -= OnCardRemoved;
        }

        private void OnCardRemoved()
        {
            DispatchCard();
        }


        public void DispatchCard()
        {
            if (transform.childCount == 0)
            {
                return;
            }
            GameObject nextCard = transform.GetChild(0).gameObject;
            if (transform.childCount == 1)
            {
                m_events.Queue.OnQueueEmptied();
            }

            m_data.CurrentCard = nextCard;
        }
    }
}