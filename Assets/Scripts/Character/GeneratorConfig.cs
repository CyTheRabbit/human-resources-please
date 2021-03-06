using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Configs/Character Generator")]
    public class GeneratorConfig : ScriptableObject
    {
        [SerializeField] private string m_filename = null;
        [SerializeField] private string[] m_names = null;
        [SerializeField, TextArea(minLines: 3, maxLines: 7)] private string[] m_descriptions = null;
        [SerializeField] private Sprite[] m_photos = null;


        public IReadOnlyList<string> Names => m_names;
        public IReadOnlyList<string> Descriptions => m_descriptions;

        public IReadOnlyList<Sprite> Photos => m_photos;


        public void Init()
        {
            if (m_filename?.Length > 0)
            {
                string json = Resources.Load<TextAsset>(m_filename).text;
                JsonUtility.FromJsonOverwrite(json, this);
            }
        }
    }
}
