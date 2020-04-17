using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(fileName = "Quest Manager", menuName = "Managers/Quests", order = 0)]
    public class QuestManager : BaseManager
    {
        [SerializeField] private QuestPool[] m_questPools = null;


        public override void Init()
        {
            foreach (QuestPool pool in m_questPools)
            {
                pool.Init();
            }
        }
    }
}
