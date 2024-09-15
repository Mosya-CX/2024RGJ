using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileEffect : ScriptableObject
{
    // 生效时调用
    public abstract void BaseApply(MissileInfo info, Vector3 dir);
    public abstract void NonApply(MissileInfo info, Vector3 dir);
    public abstract void GoodApply(MissileInfo info, Vector3 dir);
    public abstract void GreatApply(MissileInfo info, Vector3 dir);
    public abstract void PrefectApply(MissileInfo info, Vector3 dir);
}
