using System;
using Company;
using Queue;
using UnityEngine;

public class EventManager : BaseManager
{
    [SerializeField] private QueueEvents m_queue = null;
    [SerializeField] private CompanyEvents m_company = null;


    public event Action GameOver = null;


    public CompanyEvents Company => m_company;
    public QueueEvents Queue => m_queue;


    public override void Init()
    {
    }

    public void OnGameOver()
    {
        GameOver?.Invoke();
    }
}