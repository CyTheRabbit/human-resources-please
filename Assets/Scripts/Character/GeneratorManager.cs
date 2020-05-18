using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Managers/Generator")]
    public class GeneratorManager : BaseManager
    {
        [SerializeField] private GeneratorConfig m_configs = null;

        private readonly Queue<string> namePool = new Queue<string>();
        private readonly Queue<string> descPool = new Queue<string>();
        private readonly Queue<Sprite> photoPool = new Queue<Sprite>();


        private void Refill<T>(Queue<T> queue, IEnumerable<T> source)
        {
            foreach (T item in Utils.Shuffle(source.ToArray()))
            {
                queue.Enqueue(item);
            }
        }
        
        
        public override void Init()
        {
            m_configs.Init();
        }

        public string GenerateName(IEnumerable<string> tags)
        {
            if (namePool.Count == 0) Refill(namePool, m_configs.Names);
            return namePool.Dequeue();
        }

        public string GenerateDescription(string[] tags)
        {
            if (descPool.Count == 0) Refill(descPool, m_configs.Descriptions);
            return descPool.Dequeue();
        }

        public Sprite GeneratePhoto(string[] tags)
        {
            if (photoPool.Count == 0) Refill(photoPool, m_configs.Photos);
            return photoPool.Dequeue();
        }
    }
}