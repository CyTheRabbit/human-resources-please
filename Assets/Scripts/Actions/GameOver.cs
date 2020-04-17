using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Game Over")]
    public class GameOver : BaseAction
    {
        [SerializeField] private DataManager m_data = null;


        protected override void Act()
        {
            m_data.CanDispatch = false;
        }
    }
}