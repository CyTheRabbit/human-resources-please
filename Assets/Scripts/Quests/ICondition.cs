using System;
using UnityEngine.EventSystems;

namespace Quests
{
    public interface ICondition : IEventSystemHandler
    {
        bool Passed { get; }
        bool Failed { get; }

        void Init(Action refreshAction);
        void Stop();
    }
}
