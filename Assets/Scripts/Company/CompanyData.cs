using UnityEngine;

namespace Company
{
    [CreateAssetMenu(menuName = "Data/Company")]
    public class CompanyData : ScriptableObject
    {
        [SerializeField] private MetricData[] m_metrics = null;
        [SerializeField] private CompanyEvents m_events = null;


        private int employeeCount = 0;
        private int questCount = 0;


        public MetricData[] Metrics => m_metrics;

        public int EmployeeCount
        {
            get => employeeCount;
            set
            {
                employeeCount = value;
                if (value > MaxEmployeeCount) MaxEmployeeCount = value;
            }
        }

        public int QuestCount
        {
            get => questCount;
            set
            {
                questCount = value;
                if (value > MaxQuestCount) MaxQuestCount = value;
            }
        }

        public int MaxEmployeeCount
        {
            get => PlayerPrefs.GetInt(name + " Best Employees");
            set => PlayerPrefs.SetInt(name + " Best Employees", value);
        }

        public int MaxQuestCount
        {
            get => PlayerPrefs.GetInt(name + " Best Quests");
            set => PlayerPrefs.SetInt(name + " Best Quests", value);
        }


        public void Init()
        {
            employeeCount = 0;
            questCount = 0;

            m_events.EmployeeHired += () => EmployeeCount++;
            m_events.QuestCompleted += () => QuestCount++;
        }
    }
}