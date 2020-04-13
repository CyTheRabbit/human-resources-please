using Company;
using UnityEngine;

/// <summary>
/// DataManager stores current state of the game,
/// that is not easily accessible from scene hierarchy.
/// </summary>
[CreateAssetMenu(fileName = "Data Manager", menuName = "Managers/Data Manager", order = 0)]
public class DataManager : BaseManager
{
    [SerializeField] private EventManager m_events = null;
    [SerializeField] private MetricData[] m_metrics = null;


    private GameObject currentCard;


    public MetricData[] Metrics => m_metrics;

    public GameObject CurrentCard
    {
        get => currentCard;
        set
        {
            m_events.Queue.OnBeforeCardChanged();
            currentCard = value;
            m_events.Queue.OnCardChanged();
        }
    }


    public override void Init()
    {
        currentCard = null;
        foreach (MetricData metric in Metrics) metric.Init();
    }
}