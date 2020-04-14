using Quests;
using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Start Quest")]
    public class StartQuest : BaseAction
    {
        [SerializeField] private GameObject m_quest = null;


        protected override void Act()
        {
            Transform quests = GameObject.FindWithTag("Quests").transform;
            BaseQuest quest = Instantiate(m_quest, quests, false).GetComponent<BaseQuest>();
            quest.Init();
        }
    }
}