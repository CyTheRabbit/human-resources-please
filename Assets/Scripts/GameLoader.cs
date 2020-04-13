using UnityEngine;
using UnityEngine.Events;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private UnityEvent m_onStart = null;


    public void Start()
    {
        m_onStart.Invoke();
    }
}