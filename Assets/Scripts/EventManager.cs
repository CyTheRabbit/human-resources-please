using System;
using Queue;
using UnityEngine;

public class EventManager : ScriptableObject
{
    [SerializeField] private QueueEvents m_queue = null;


    public class CompanyEvents
    {
        public event Action MetricChanged = null;
        public event Action MetricEmptied = null;

        public void OnMetricChanged()
        {
            MetricChanged?.Invoke();
        }

        public void OnMetricEmptied()
        {
            MetricEmptied?.Invoke();
        }
    }

    private CompanyEvents company = null;


    public CompanyEvents Company => company;
    public QueueEvents Queue => m_queue;


    public void Init()
    {
        company = new CompanyEvents();
    }
}