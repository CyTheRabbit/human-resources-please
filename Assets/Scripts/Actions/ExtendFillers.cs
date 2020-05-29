using Filler;
using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Extend Fillers")]
    public class ExtendFillers : BaseAction
    {
        [SerializeField] private FillerGenerator m_pool = null;
        [SerializeField] private GameObject[] m_cards = null;


        protected override void Act()
        {
            m_pool.Extend(m_cards);
        }
    }
}