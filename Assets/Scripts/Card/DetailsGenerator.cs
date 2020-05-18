using Character;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Card
{
    [AddComponentMenu("Cards/Details Generator")]
    public class DetailsGenerator : MonoBehaviour, IViewable
    {
        [SerializeField] private GeneratorManager m_generator = null;
        [SerializeField] private string[] m_tags = null;
        [Space]
        [SerializeField] private Text m_name = null;
        [SerializeField] private Text m_description = null;
        [SerializeField] private Image m_photo = null;
        [Space]
        [SerializeField, TextArea(3, 7)] private string[] m_customDescriptions = null;


        private void GenerateDetails()
        {
            if (m_name != null) m_name.text = m_generator.GenerateName(m_tags);
            if (m_description != null)
            {
                m_description.text = m_customDescriptions?.Length > 0
                    ? Utils.PickRandom(m_customDescriptions)
                    : m_generator.GenerateDescription(m_tags);
            }
            if (m_photo != null) m_photo.sprite = m_generator.GeneratePhoto(m_tags);
        }


        public void Show() { }

        public void Hide() { }

        public void Refresh()
        {
            GenerateDetails();
            Destroy(this);
        }
    }
}