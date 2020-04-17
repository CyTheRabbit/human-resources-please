using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static T PickRandom<T>(IReadOnlyList<T> elements)
    {
        return elements[Random.Range(0, elements.Count)];
    }
}