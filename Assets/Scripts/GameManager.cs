using Character;
using UI;
using UnityEngine;

public class GameManager : ScriptableObject
{
    private GameConfig config = null;
    private EventManager events = null;

    private SwipeController swipeController = null;
    private SwipeAnimator swipeAnimator = null;

    private Transform gameCanvas = null;
    private CharacterData currentCharacter = null;
    private View<CharacterData> currentCharacterView = null;
        
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
        return new CharacterData
        {
            m_name = "New Character",
            m_description = "+"
        };
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

    public void Init(GameConfig gameConfig, EventManager eventManager)
    {
        config = gameConfig;
        events = eventManager;

        gameCanvas = Instantiate(config.m_gameCanvasPrefab).transform;
        
        currentCharacterView = Instantiate(config.m_characterCardPrefab, gameCanvas).GetComponent<View<CharacterData>>();

        swipeController = Instantiate(config.m_swipeControllerPrefab).GetComponent<SwipeController>();
        
        swipeAnimator = swipeController.GetComponent<SwipeAnimator>();
        swipeAnimator.Init();
        swipeAnimator.Target = currentCharacterView.GetComponent<RectTransform>();
        swipeAnimator.SwipedOutLeft += Skip;
        swipeAnimator.SwipedOutRight += Hire;
        
        ShowNextCard();
    }
}
