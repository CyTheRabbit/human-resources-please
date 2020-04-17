using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Detects and dispatches events of player swiping or dragging items on scene. Basically, tinder style swipe.
    /// </summary>
    /// <remarks>
    /// TiltLeft and TiltRight events are invoked when user intents to swipe in the direction and should be
    /// used to indicate action that swiping in that direction will launch.
    /// </remarks>
    public class SwipeController : MonoBehaviour
    {
        public event Action SwipedLeft = null;
        public event Action SwipedRight = null;
        public event Action TiltedLeft = null;
        public event Action TiltedRight = null;
        public event Action Canceled = null;
        public event Action<float> Dragged = null;

        
        [SerializeField] private SwipeConfig m_config = null;

        
        private const float Rest_Tilt = 0.5f;

        private Vector3 originPosition = Vector3.zero;
        private float tiltPercent = Rest_Tilt;

        private float TiltPercent
        {
            get => tiltPercent;
            set
            {
                tiltPercent = value;
                Dragged?.Invoke(tiltPercent);
            }
        }

        private float TiltLeftPercent => Rest_Tilt - m_config.m_tiltTriggerPercent;
        private float TiltRightPercent => Rest_Tilt + m_config.m_tiltTriggerPercent;
        private float SwipeLeftPercent => Rest_Tilt - m_config.m_swipeTriggerPercent;
        private float SwipeRightPercent => Rest_Tilt + m_config.m_swipeTriggerPercent;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                originPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (TiltPercent <= SwipeLeftPercent) SwipedLeft?.Invoke();
                else if (TiltPercent >= SwipeRightPercent) SwipedRight?.Invoke();
                else Canceled?.Invoke();
                tiltPercent = Rest_Tilt;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector2 position = Input.mousePosition;
                float newTiltPercent = Rest_Tilt + (position.x - originPosition.x) / m_config.m_dragPositionScale;
                newTiltPercent = Mathf.Clamp(newTiltPercent,
                    Rest_Tilt - m_config.m_maxPercentTilt,
                    Rest_Tilt + m_config.m_maxPercentTilt);
                if (TiltPercent > TiltLeftPercent && newTiltPercent <= TiltLeftPercent) TiltedRight?.Invoke();
                else if (TiltPercent < TiltRightPercent && newTiltPercent >= TiltRightPercent) TiltedLeft?.Invoke();
                TiltPercent = newTiltPercent;
            }
        }
    }
}
