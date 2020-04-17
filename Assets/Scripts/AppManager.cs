using UnityEngine;

/// <summary>
/// Application entry point to initialize core game managers
/// and to set application constants.
/// </summary>
public class AppManager : ScriptableObject
{
    [SerializeField] private int m_editorFrameRate = 60;

    [SerializeField] private BaseManager[] m_managers = null;


    private static AppManager _instance = null;


    public static AppManager Instance => _instance;


    public void Init()
    {
#if UNITY_EDITOR
        Application.targetFrameRate = m_editorFrameRate;
#endif
        foreach (BaseManager manager in m_managers) manager.Init();
    }

    private const string AppManagerPath = "Application Manager";
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnLoad() => _instance = Instantiate(Resources.Load<AppManager>(AppManagerPath));

}
