using UnityEngine;

namespace Actions
{
    [AddComponentMenu("Actions/Play Sound")]
    public class PlaySound : BaseAction
    {
        [SerializeField] private AudioClip m_sound = null;
        
        protected override void Act()
        {
            FindObjectOfType<SoundSystem>().Play(m_sound);
        }
    }
}