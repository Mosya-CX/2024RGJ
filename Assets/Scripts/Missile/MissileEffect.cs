using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileEffect : ScriptableObject
{
    // 生效时调用
    public abstract void Apply();
}
