using System;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Configs/Job Position")]
    public class JobPosition : ScriptableObject
    {
        public event Action Hired = null;
        public event Action Skipped = null;


        [SerializeField] private string m_shownName = null;


        public string ShownName => m_shownName;


        public void Hire()
        {
            Hired?.Invoke();
            Resources.FindObjectsOfTypeAll<EventManager>()[0].Company.OnEmployeeHired();
        }

        public void Skip()
        {
            Skipped?.Invoke();
        }
    }
}