using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Game Over")]
    public class GameOver : BaseAction
    {
        [SerializeField] private DataManager m_data = null;
        [SerializeField] private EventManager m_events = null;


        protected override void Act()
        {
            m_events.OnGameOver();
            m_data.CanDispatch = false;
        }
    }
}