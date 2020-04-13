using UnityEngine;

/// <summary>
/// Application entry point to initialize core game managers
/// and to set application constants.
/// </summary>
public class AppManager : ScriptableObject
{
    [SerializeField] private int m_editorFrameRate = 60;

    [SerializeField] private EventManager m_events = null;
    [SerializeField] private ConfigManager m_config = null;

    private void Init()
    {
#if UNITY_EDITOR
        Application.targetFrameRate = m_editorFrameRate;
#endif
    }

    private const string AppManagerPath = "Application Manager";
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnLoad() => Instantiate(Resources.Load<AppManager>(AppManagerPath)).Init();
}
