using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Change Background")]
    public class ChangeBackground : BaseAction
    {
        [SerializeField] private Sprite m_sprite = null;


        protected override void Act()
        {
            GameObject.Find("Scene Background").GetComponent<SpriteRenderer>().sprite = m_sprite;
        }
    }
}