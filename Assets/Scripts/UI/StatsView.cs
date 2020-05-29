using Company;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StatsView : MonoBehaviour, IViewable
    {
        [SerializeField] private CompanyData m_company = null;
        [Space]
        [SerializeField, Multiline] private string m_employeeCountFormat = null;
        [SerializeField] private Text m_employeeCounter = null;
        [Space]
        [SerializeField, Multiline] private string m_questCountFormat = null;
        [SerializeField] private Text m_questCounter = null;


        public void Show() { }

        public void Hide() { }

        public void Refresh()
        {
            m_employeeCounter.text = string.Format(m_employeeCountFormat, m_company.EmployeeCount, m_company.MaxEmployeeCount);
            m_questCounter.text = string.Format(m_questCountFormat, m_company.QuestCount, m_company.MaxQuestCount);
        }
    }
}