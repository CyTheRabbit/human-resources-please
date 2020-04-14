using Character;
using UnityEngine;

namespace Card
{
    public class EmployeeCard : MonoBehaviour, ISwipable
    {
        [SerializeField] private JobPosition m_position = null;


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