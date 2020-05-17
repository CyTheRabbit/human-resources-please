using Card;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ConfigManager m_configs = null;
    [SerializeField] private EventManager m_events = null;
    [SerializeField] private DataManager m_data = null;
    [Space]
    [SerializeField] private SwipeController m_swipeController = null;
    [SerializeField] private SwipeAnimator m_swipeAnimator = null;
    [SerializeField] private RectTransform m_cardParent = null;


    private void Awake()
    {
        Init();
    }

    private static void RevealEvent(ISwipable card, BaseEventData _)
    {
        card.Reveal();
    }

    private void SwipeStartEvent(ISwipable card, BaseEventData _)
    {
        card.SwipeStart();
    }

    private static void SwipeLeftEvent(ISwipable card, BaseEventData _)
    {
        card.SwipeLeft();
    }

    private static void SwipeRightEvent(ISwipable card, BaseEventData _)
    {
        card.SwipeRight();
    }
    
        
    private void ShowNextCard()
    {
        if (!m_data.CanDispatch) return;
        GameObject card = m_data.CurrentCard;
        card.transform.SetParent(m_cardParent, false);
        ExecuteEvents.Execute<IViewable>(card, null, BaseView.RefreshEvent);
        ExecuteEvents.Execute<IViewable>(card, null, BaseView.ShowEvent);
        ExecuteEvents.Execute<ISwipable>(card, null, RevealEvent);
        m_swipeAnimator.ResetAnimations();
    }

    private void HidePrevCard()
    {
        GameObject card = m_data.CurrentCard;
        ExecuteEvents.Execute<IViewable>(card, null, BaseView.HideEvent);
        Destroy(card);
    }
    
    private void OnSwipeStarted()
    {
        ExecuteEvents.Execute<ISwipable>(m_data.CurrentCard, null, SwipeStartEvent);
    }

    private void OnSwipeLeft()
    {
        ExecuteEvents.Execute<ISwipable>(m_data.CurrentCard, null, SwipeLeftEvent);
        m_events.Queue.OnCardRemoved();
    }
    
    private void OnSwipeRight()
    {
        ExecuteEvents.Execute<ISwipable>(m_data.CurrentCard, null, SwipeRightEvent);
        m_events.Queue.OnCardRemoved();
    }


    public void Init()
    {
        m_swipeAnimator.Init();
        m_swipeAnimator.Target = m_cardParent;
        m_swipeAnimator.SwipedOutLeft += OnSwipeLeft;
        m_swipeController.SwipedLeft += OnSwipeStarted;
        m_swipeController.SwipedRight += OnSwipeStarted;
        m_swipeAnimator.SwipedOutRight += OnSwipeRight;
        
        m_events.Queue.BeforeCardChanged += HidePrevCard;
        m_events.Queue.CardChanged += ShowNextCard;
    }
}
