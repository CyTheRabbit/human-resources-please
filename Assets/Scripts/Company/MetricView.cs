using Animations;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Company
{
    public class MetricView : View<MetricData>
    {
        [SerializeField] private Image m_valueBar = null;
        [SerializeField] private Text m_name = null;

        private PropertyAnimation fillAnimation = null;
        
        public override void Init(MetricData model)
        {
            base.Init(model);

            fillAnimation = new PropertyAnimation(this, model.Config.m_barFill, SetFill) 
                {EndValue = 0, StartValue = 0};

            m_valueBar.color = Model.Config.m_color;
            m_name.text = Model.Config.m_name;
            Refresh();
        }

        private void SetFill(float fillAmount)
        {
            m_valueBar.fillAmount = fillAmount;
        }

        public override void Refresh()
        {
            if (Mathf.Approximately(fillAnimation.EndValue, Model.Value)) return;
            fillAnimation.StartValue = fillAnimation.EndValue;
            fillAnimation.EndValue = Model.Value;
            fillAnimation.Start();
        }
    }
}