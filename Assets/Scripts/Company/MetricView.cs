using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Company
{
    public class MetricView : View<MetricData>
    {
        [SerializeField] private Image m_valueBar = null;
        [SerializeField] private Text m_name = null;

        
        public override void Init(MetricData model)
        {
            base.Init(model);
            m_valueBar.color = Model.Config.m_color;
            m_name.text = Model.Config.m_name;
            Refresh();
        }

        public override void Refresh()
        {
            m_valueBar.fillAmount = Model.Value;
        }
    }
}