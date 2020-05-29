using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Quests
{
    [AddComponentMenu("Base Quest")]
    public class BaseQuest : MonoBehaviour
    {
        [SerializeField] private bool m_autoStart = false;


        private bool isRunning = false;


        private void Start()
        {
            if (m_autoStart) Init();
        }

        private void OnDestroy()
        {
            if (!isRunning) return;
            ExecuteEvents.Execute<IOutcome>(gameObject, null, StopEvent);
            ExecuteEvents.Execute<ICondition>(gameObject, null, StopEvent);
        }


        private void Refresh()
        {
            bool passed = true;
            bool failed = false;
            ExecuteEvents.Execute(gameObject, null, delegate(ICondition test, BaseEventData _)
            {
                if (!test.Passed) passed = false;
                if (test.Failed) failed = true;
            });
            if (failed)
            {
                Debug.Log($"Quest \"{name}\" failed");
                ExecuteEvents.Execute<IOutcome>(gameObject, null, FailEvent);
                ExecuteEvents.Execute<IOutcome>(gameObject, null, StopEvent);
                ExecuteEvents.Execute<ICondition>(gameObject, null, StopEvent);

                isRunning = false;
            }
            else if (passed)
            {
                Debug.Log($"Quest \"{name}\" completed");
                ExecuteEvents.Execute<IOutcome>(gameObject, null, PassEvent);
                ExecuteEvents.Execute<IOutcome>(gameObject, null, StopEvent);
                ExecuteEvents.Execute<ICondition>(gameObject, null, StopEvent);

                Resources.FindObjectsOfTypeAll<EventManager>()[0].Company.OnQuestCompleted();

                isRunning = false;
            }
        }


        public void Init()
        {
            ExecuteEvents.Execute<ICondition>(gameObject, null, InitEvent);
            ExecuteEvents.Execute<IOutcome>(gameObject, null, PrepareEvent);
            isRunning = true;
        }


        private static void FailEvent(IOutcome reward, BaseEventData _) => reward.Fail();
        private static void PassEvent(IOutcome reward, BaseEventData _) => reward.Pass();
        private static void PrepareEvent(IOutcome test, BaseEventData _) => test.Prepare();
        private static void StopEvent(IOutcome test, BaseEventData _) => test.Stop();
        private static void StopEvent(ICondition test, BaseEventData _) => test.Stop();
        private void InitEvent(ICondition test, BaseEventData _) => test.Init(Refresh);
    }
}