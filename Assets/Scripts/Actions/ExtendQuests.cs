using Quests;
using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Extend Quests")]
    public class ExtendQuests : BaseAction
    {
        [SerializeField] private QuestPool m_pool = null;
        [SerializeField] private GameObject[] m_quests = null;
        

        protected override void Act()
        {
            m_pool.Extend(m_quests);
        }
    }
}