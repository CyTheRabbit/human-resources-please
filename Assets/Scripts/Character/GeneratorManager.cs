using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Managers/Generator")]
    public class GeneratorManager : BaseManager
    {
        [SerializeField] private GeneratorConfig m_configs = null;
        
        
        public override void Init()
        {
        }

        public string GenerateName(IEnumerable<string> tags)
        {
            return Utils.PickRandom(m_configs.Names);
        }

        public string GenerateDescription(string[] tags)
        {
            return Utils.PickRandom(m_configs.Descriptions);
        }

        public Sprite GeneratePhoto(string[] tags)
        {
            return Utils.PickRandom(m_configs.Photos);
        }
    }
}