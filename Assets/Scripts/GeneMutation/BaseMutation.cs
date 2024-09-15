using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMutation : ScriptableObject
{
    public abstract bool TryMutate();
}
