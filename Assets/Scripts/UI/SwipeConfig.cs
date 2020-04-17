using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "Configs/Swipe")]
    public class SwipeConfig : ScriptableObject
    {
        [Header("Input config")]
        
        public float m_dragPositionScale = 150.0f;
        public float m_maxPercentTilt = 0.5f;

        [Header("Trigger areas")]
        
        public float m_tiltTriggerPercent = 0.0f;
        public float m_swipeTriggerPercent = 1.0f;
        
        [Header("Animation config")]
        
        public float m_maxTiltAngle = 45f;
        public float m_maxSlideDistance = 0.4f;
        public float m_swipeOutDistance = 3000;
    }
}
