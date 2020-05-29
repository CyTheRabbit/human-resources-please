using UnityEngine;

namespace Filler
{
    [CreateAssetMenu(fileName = "Filler Config", menuName = "Configs/Filler", order = 0)]
    public class FillerConfig : ScriptableObject
    {
        [SerializeField] private GameObject[] m_employeePrefabs = null;


        public GameObject[] Prefabs => m_employeePrefabs;


        public GameObject PickRandom()
        {
            return Utils.PickRandom(m_employeePrefabs);
        }
    }
}