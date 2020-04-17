using Queue;
using UnityEngine;

namespace Filler
{
    [CreateAssetMenu(fileName = "Filler Generator", menuName = "Managers/Filler Generator", order = 0)]
    public class FillerGenerator : ScriptableObject
    {
        [SerializeField] private FillerConfig m_fillerConfig = null;


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
