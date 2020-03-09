using Animations;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CharacterView : View<CharacterData>
    {
        [SerializeField] private Text m_nameText = null;
        [SerializeField] private Text m_descriptionText = null;

        [Header("Animations")]
        
        [SerializeField] private AnimationConfig m_showAlpha = null;
        [SerializeField] private AnimationConfig m_showScale = null;

        private CanvasGroup group = null;
        private PropertyAnimation showAlphaAnimation = null;
        private PropertyAnimation showScaleAnimation = null;

        private void Awake()
        {
            group = GetComponent<CanvasGroup>();

            showAlphaAnimation = new PropertyAnimation(this, m_showAlpha, UpdateAlpha)
                {StartValue = 0.0f, EndValue = 1.0f};
            showScaleAnimation = new PropertyAnimation(this, m_showScale, UpdateScale)
                {StartValue = 0.0f, EndValue = 1.0f};
        }


        private void UpdateAlpha(float alpha) => group.alpha = alpha;
        private void UpdateScale(float scale) => transform.localScale = Vector3.one * scale;

        
        public override void Init(CharacterData model)
        {
            base.Init(model);

            m_nameText.text = Model.m_name;
            m_descriptionText.text = Model.m_description;
        }
        
        public override void Show()
        {
            Visible = true;
            showAlphaAnimation.Start();
            showScaleAnimation.Start();
        }

        public override void Hide() => Visible = false;
    }
}