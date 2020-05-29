using System;
using System.Collections.Generic;
using Queue;
using UnityEngine;

namespace Filler
{
    [CreateAssetMenu(fileName = "Filler Generator", menuName = "Managers/Filler Generator", order = 0)]
    public class FillerGenerator : BaseManager
    {
        [SerializeField] private FillerConfig m_fillerConfig = null;


        private readonly List<GameObject> m_cards = new List<GameObject>();


        public override void Init()
        {
            m_cards.Clear();
            m_cards.AddRange(m_fillerConfig.Prefabs);
        }

        public void Extend(IEnumerable<GameObject> cards)
        {
            m_cards.AddRange(cards);
        }

        public void Generate(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject card = Instantiate(m_fillerConfig.PickRandom());
                QueueUtils.Enroll(card, int.MaxValue);
            }
        }
    }
}
