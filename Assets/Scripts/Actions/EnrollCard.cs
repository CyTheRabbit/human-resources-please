using Queue;
using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Enroll Cards")]
    public class EnrollCard : BaseAction
    {
        [SerializeField] private GameObject[] m_cards = null;
        [SerializeField] private int m_rangeFrom = 0;
        [SerializeField] private int m_rangeTo = 0;


        protected override void Act()
        {
            foreach (GameObject prefab in m_cards)
            {
                Debug.Log($"Added \"{prefab.name}\" card to queue");
                GameObject card = Instantiate(prefab);
                QueueUtils.EnrollAtRandomPosition(card, m_rangeFrom, m_rangeTo);
            }
        }
    }
}