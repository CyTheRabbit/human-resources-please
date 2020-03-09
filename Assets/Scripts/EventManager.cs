using System;
using Character;
using UnityEngine;

public class EventManager : ScriptableObject
{
    [NonSerialized] public Action<CharacterData> CharacterHired = null;
    [NonSerialized] public Action<CharacterData> CharacterSkipped = null;
    [NonSerialized] public Action<string, float> MetricChanged = null;
    [NonSerialized] public Action<string> MetricEnded = null;
}
