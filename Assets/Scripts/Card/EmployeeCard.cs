using Character;
using UnityEngine;
using UnityEngine.UI;

namespace Card
{
    public class EmployeeCard : MonoBehaviour, ISwipable
    {
        [SerializeField] private Text m_text = null;
        [SerializeField] private JobPosition m_position = null;


        private void Awake()
        {
            Debug.Assert(m_position != null, $"{name} has no job position set!");
            m_text.text = m_position.ShownName;
        }
        

        public void SwipeLeft()
        {
            m_position.Skip();
        }

        public void SwipeRight()
        {
            m_position.Hire();
        }
    }
}