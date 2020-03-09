using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Game", order = 0)]
public class GameConfig : ScriptableObject
{
    public GameObject m_gameCanvasPrefab = null;
    public GameObject m_characterCardPrefab = null;
    public GameObject m_swipeControllerPrefab = null;
}
