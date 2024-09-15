using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileEffect : ScriptableObject
{
    // ��Чʱ����
    public abstract void BaseApply(MissileInfo info);
    public abstract void NonApply(MissileInfo info);
    public abstract void GoodApply(MissileInfo info);
    public abstract void GreatApply(MissileInfo info);
    public abstract void PrefectApply(MissileInfo info);
}
