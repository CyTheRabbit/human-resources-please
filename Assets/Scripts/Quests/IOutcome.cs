using UnityEngine.EventSystems;

namespace Quests
{
    public interface IOutcome : IEventSystemHandler
    {
        void Pass();
        void Fail();
        void Prepare();
        void Stop();
    }
}