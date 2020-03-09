using Character;
using Company;
using UI;
using UnityEngine;

public class GameManager : ScriptableObject
{
    private GameConfig config = null;
    private EventManager events = null;

    private SwipeController swipeController = null;
    private SwipeAnimator swipeAnimator = null;
    private CharacterGenerator generator = null;

    private Transform gameCanvas = null;
    private CharacterData currentCharacter = null;
    private CompanyData company = null;
    private View<CharacterData> currentCharacterView = null;
    private View<CompanyData> companyView = null;
    
        
    private void ShowNextCard()
    {
        currentCharacter = GetNextCharacter();
        
        currentCharacterView.Hide();
        currentCharacterView.Init(currentCharacter);
        currentCharacterView.Show();

        swipeAnimator.ResetAnimations();
    }

    private CharacterData GetNextCharacter()
    {
        return generator.Generate();
    }

    private void Hire()
    {
        events.CharacterHired?.Invoke(currentCharacter);
        ShowNextCard();
    }
    
    private void Skip()
    {
        events.CharacterSkipped?.Invoke(currentCharacter);
        ShowNextCard();
    }
    
    private void OnMetricChanged(string metricName, float newValue)
    {
        companyView.Refresh();
    }


    public void Init(GameConfig gameConfig, EventManager eventManager)
    {
        config = gameConfig;
        events = eventManager;

        gameCanvas = Instantiate(config.m_gameCanvasPrefab).transform;

        generator = CreateInstance<CharacterGenerator>();
        generator.Init(config.m_generator);
        
        currentCharacterView = Instantiate(config.m_characterCardPrefab, gameCanvas).GetComponent<View<CharacterData>>();
        
        company = CreateInstance<CompanyData>();
        company.Init(config.m_companyConfig, events);

        companyView = Instantiate(config.m_companyUiPrefab).GetComponent<View<CompanyData>>();
        companyView.Init(company);

        swipeController = Instantiate(config.m_swipeControllerPrefab).GetComponent<SwipeController>();
        
        swipeAnimator = swipeController.GetComponent<SwipeAnimator>();
        swipeAnimator.Init();
        swipeAnimator.Target = currentCharacterView.GetComponent<RectTransform>();
        swipeAnimator.SwipedOutLeft += Skip;
        swipeAnimator.SwipedOutRight += Hire;
        
        events.MetricChanged += OnMetricChanged;
        
        ShowNextCard();
    }
}
