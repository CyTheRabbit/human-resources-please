using System;
using Animations;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(SwipeController))]
    public class SwipeAnimator : MonoBehaviour
    {
        public event Action SwipedOutLeft;
        public event Action SwipedOutRight;
        
        [SerializeField] private Graphic m_target = null;
        [SerializeField] private SwipeConfig m_config = null;
        
        [Header("Animations")]
        
        [SerializeField] private AnimationConfig m_tiltConfig = null;
        [SerializeField] private AnimationConfig m_slideConfig = null;
        [SerializeField] private AnimationConfig m_swipeOutConfig = null;
        [SerializeField] private AnimationConfig m_cancelConfig = null;

        private const float Rest_Tilt = 0.5f;

        private SwipeController controller = null;
        private new RectTransform transform = null;
        private PropertyCurve tiltAnimation = null;
        private PropertyCurve slideAnimation = null;
        private PropertyAnimation swipeOutAnimation = null;
        private PropertyAnimation cancelAnimation = null;
        
        public RectTransform Target
        {
            get => transform;
            set
            {
                if (transform != null) ResetAnimations();
                transform = value;
            }
        }

        public void OnDestroy()
        {
            swipeOutAnimation.Finish();
            cancelAnimation.Finish();
        }


        private void UpdateRotationAnimated(float value)
        {
            float angle = (value - Rest_Tilt) * 2 * m_config.m_maxTiltAngle;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        private void UpdatePosition(float value)
        {
            transform.anchoredPosition = Vector2.right * value;
        }
        
        private void UpdatePositionAnimated(float value)
        {
            float pivotOffset = (value - Rest_Tilt) * 2 * m_config.m_maxSlideDistance;
            transform.anchoredPosition = Vector2.right * pivotOffset;
        }

        private void OnDragged(float percent)
        {
            tiltAnimation.Progress = percent;
            slideAnimation.Progress = percent;
        }

        private void OnCancel()
        {
            cancelAnimation.StartValue = tiltAnimation.Progress;
            cancelAnimation.EndValue = 0.5f;
            cancelAnimation.Start();
        }

        private void OnSwipedLeft()
        {
            swipeOutAnimation.StartValue = transform.anchoredPosition.x;
            swipeOutAnimation.EndValue = -m_config.m_swipeOutDistance;
            swipeOutAnimation.Start(() => SwipedOutLeft?.Invoke());
        }

        private void OnSwipedRight()
        {
            swipeOutAnimation.StartValue = transform.anchoredPosition.x;
            swipeOutAnimation.EndValue = +m_config.m_swipeOutDistance;
            swipeOutAnimation.Start(() => SwipedOutRight?.Invoke());
        }


        public void ResetAnimations()
        {
            if (transform == null) return;
            swipeOutAnimation.Cancel();
            cancelAnimation.Cancel();
            OnDragged(Rest_Tilt);
        }

        public void Init()
        {
            controller = GetComponent<SwipeController>();
            if (m_target != null) Target = m_target.GetComponent<RectTransform>();

            tiltAnimation = new PropertyCurve(m_tiltConfig, UpdateRotationAnimated);
            slideAnimation = new PropertyCurve(m_slideConfig, UpdatePositionAnimated);
            swipeOutAnimation = new PropertyAnimation(this, m_swipeOutConfig, UpdatePosition);
            cancelAnimation = new PropertyAnimation(this, m_cancelConfig, OnDragged);

            controller.Dragged += OnDragged;
            controller.Canceled += OnCancel;
            controller.SwipedLeft += OnSwipedLeft;
            controller.SwipedRight += OnSwipedRight;
        }
    }
}
