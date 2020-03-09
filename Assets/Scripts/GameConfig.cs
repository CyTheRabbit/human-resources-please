using Character;
using Company;
using UnityEngine;

public class GameConfig : ScriptableObject
{
    public GameObject m_gameCanvasPrefab = null;
    public GameObject m_characterCardPrefab = null;
    public GameObject m_swipeControllerPrefab = null;
    public GameObject m_companyUiPrefab = null;
    
    public CompanyConfig m_companyConfig = null;
}
