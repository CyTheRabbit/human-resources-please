using UnityEngine;

namespace Queue
{
    public static class QueueUtils
    {
        public static Transform QueueTransform => GameObject.FindWithTag("Queue").transform;


        private static int ClampPosition(int position)
        {
            return Mathf.Min(position, QueueTransform.childCount);
        }

        private static int PickRandomPosition(int from = 0, int to = int.MaxValue)
        {
            from = ClampPosition(from);
            to = ClampPosition(to);
            return Random.Range(from, to);
        }


        public static void Enroll(GameObject card, int position)
        {
            card.transform.SetParent(QueueTransform, false);
            card.transform.SetSiblingIndex(ClampPosition(position));
        }

        public static void EnrollAtRandomPosition(GameObject card, int from = 0, int to = int.MaxValue)
        {
            card.transform.SetParent(QueueTransform, false);
            card.transform.SetSiblingIndex(PickRandomPosition(from, to));
        }
    }
}
