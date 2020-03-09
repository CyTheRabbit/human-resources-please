using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Company
{
    public class CompanyView : View<CompanyData>
    {
        [SerializeField] private RectTransform m_metricsParent = null;
        [SerializeField] private GameObject m_metricViewPrefab = null;
        
        private readonly List<View<MetricData>> metrics = new List<View<MetricData>>();

        public override void Init(CompanyData model)
        {
            base.Init(model);

            foreach (MetricData metric in Model.Metrics)
            {
                View<MetricData> view = Instantiate(m_metricViewPrefab, m_metricsParent)
                    .GetComponent<View<MetricData>>();
                view.Init(metric);
                metrics.Add(view);
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            foreach (View<MetricData> metric in metrics) metric.Refresh();
        }
    }
}