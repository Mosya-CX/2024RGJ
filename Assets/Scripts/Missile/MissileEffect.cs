using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileEffect : ScriptableObject
{
    // 生效时调用
    public abstract void BaseApply(MissileInfo info);
    public abstract void NonApply(MissileInfo info);
    public abstract void GoodApply(MissileInfo info);
    public abstract void GreatApply(MissileInfo info);
    public abstract void PrefectApply(MissileInfo info);
}
