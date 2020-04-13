using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    public class CardsSupplier : MonoBehaviour, ISwipable
    {
        // TODO: Replace with addressable assets
        [SerializeField] private GameObject[] m_cardsOnLeft = null;
        [SerializeField] private GameObject[] m_cardsOnRight = null;


        private static void AddCards(IEnumerable<GameObject> cards)
        {
            Transform queue = GameObject.FindWithTag("Queue").transform;
            foreach (GameObject prefab in cards)
            {
                Instantiate(prefab, queue, false);
            }
        }
        
        
        public void SwipeLeft()
        {
            AddCards(m_cardsOnLeft);
        }

        public void SwipeRight()
        {
            AddCards(m_cardsOnRight);
        }
    }
}