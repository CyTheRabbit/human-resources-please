using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Enroll Cards")]
    public class EnrollCard : BaseAction
    {
        [SerializeField] private GameObject[] m_cards = null;
        [SerializeField] private RangeInt m_range = new RangeInt(0, 0);


        private int RandomChildPosition(Transform parent)
        {
            int childCount = parent.childCount;
            int min = Mathf.Min(m_range.start, childCount);
            int max = Mathf.Min(min + m_range.length, childCount);
            return Random.Range(min, max);
        }


        protected override void Act()
        {
            Transform queue = GameObject.FindWithTag("Queue").transform;
            foreach (GameObject prefab in m_cards)
            {
                GameObject instance = Instantiate(prefab, queue, false);
                int position = RandomChildPosition(queue);
                instance.transform.SetSiblingIndex(position);
            }
        }
    }
}