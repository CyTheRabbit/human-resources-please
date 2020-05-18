using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static T PickRandom<T>(IReadOnlyList<T> elements)
    {
        return elements[Random.Range(0, elements.Count)];
    }

    public static IList<T> Shuffle<T>(IList<T> elements)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            int j = Random.Range(i, elements.Count);
            (elements[i], elements[j]) = (elements[j], elements[i]);
        }
        return elements;
    }
}