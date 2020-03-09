using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterGenerator : ScriptableObject
    {
        private GeneratorConfig config = null;

        
        private static T SelectRandom<T>(IReadOnlyList<T> array)
        {
            return array[Random.Range(0, array.Count)];
        }
        

        public void Init(GeneratorConfig generatorConfig)
        {
            config = generatorConfig;
        }

        public CharacterData Generate()
        {
            Archetype archetype = SelectRandom(config.m_archetypes);
            CharacterData data = archetype.Generate();
            return data;
        }
    }
}