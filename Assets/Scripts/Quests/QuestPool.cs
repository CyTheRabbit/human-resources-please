using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quests
{
    [CreateAssetMenu(menuName = "Configs/Quest Pool")]
    public class QuestPool : ScriptableObject
    {
        [SerializeField] private GameObject[] m_quests;

        private List<GameObject> availableQuests = null;


        public GameObject PickRandom()
        {
            GameObject prefab = Utils.PickRandom(availableQuests);
            availableQuests.Remove(prefab);
            return prefab;
        }
        

        public void Init()
        {
            availableQuests = m_quests.ToList();
        }
    }
}