using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMutation : ScriptableObject
{
    public abstract string _Des { get; }
    public abstract Sprite _Sprite { get; }
    public abstract bool TryMutate();
}
