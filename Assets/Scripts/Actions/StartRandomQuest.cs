using Quests;
using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Start Random Quest")]
    public class StartRandomQuest : BaseAction
    {
        [SerializeField] private QuestPool m_questPool = null;


        protected override void Act()
        {
            GameObject prefab = m_questPool.PickRandom();
            if (prefab == null) return;
            Debug.Log($"Started quest \"{prefab.name}\"");
            Transform quests = GameObject.FindWithTag("Quests").transform;
            BaseQuest quest = Instantiate(prefab, quests, false).GetComponent<BaseQuest>();
            quest.Init();
        }
    }
}