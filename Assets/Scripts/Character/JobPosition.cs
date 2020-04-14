using System;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Configs/Job Position")]
    public class JobPosition : ScriptableObject
    {
        public event Action Hired = null;
        public event Action Skipped = null;

        public void Hire()
        {
            Hired?.Invoke();
        }

        public void Skip()
        {
            Skipped?.Invoke();
        }
    }
}