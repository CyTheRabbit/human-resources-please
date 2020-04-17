using Filler;
using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Add Filler Cards")]
    public class AddFillers : BaseAction
    {
        [SerializeField] private FillerGenerator m_generator = null;
        [SerializeField] private int m_count = 1;


        protected override void Act()
        {
            Debug.Log($"Added {m_count} filler cards");
            m_generator.Generate(m_count);
        }
    }
}