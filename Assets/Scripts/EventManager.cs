using System;
using Character;
using UnityEngine;

public class EventManager : ScriptableObject
{
    [NonSerialized] public Action<CharacterData> CharacterHired = null;
    [NonSerialized] public Action<CharacterData> CharacterSkipped = null;
}
