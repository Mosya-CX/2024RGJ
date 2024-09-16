using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1003 : BaseBullet
{
    public MissileGrade grade;
    public float chance = 0.2f;
    public override void EffectOnEnter(Enemy info)
    {
        base.EffectOnEnter(info);
        speed = 0;
        switch (grade)
        {
            case MissileGrade.Non:
                info.buffHandler.AddBuff(new BuffInfo("Data/ScriptableObject/Buff/Buff1001", gameObject, info.gameObject));
                break;
            case MissileGrade.Base:
                info.buffHandler.AddBuff(new BuffInfo("Data/ScriptableObject/Buff/Buff1001", gameObject, info.gameObject));
                info.buffHandler.AddBuff(new BuffInfo("Data/ScriptableObject/Buff/Buff1000", gameObject, info.gameObject));
                break;
            case MissileGrade.Good:
                info.buffHandler.AddBuff(new BuffInfo("Data/ScriptableObject/Buff/Buff1001", gameObject, info.gameObject));
                info.buffHandler.AddBuff(new BuffInfo("Data/ScriptableObject/Buff/Buff1000", gameObject, info.gameObject));
                RandomTakeAction(() =>
                {
                    info.buffHandler.AddBuff(new BuffInfo("Data/ScriptableObject/Buff/Buff1002", gameObject, info.gameObject));
                });
                break;
        }
        Destroy(gameObject);
    }

    public void RandomTakeAction(Action action)
    {
        float rand = UnityEngine.Random.Range(0f, 1f);
        if (rand <= chance)
        {
            action.Invoke();
        }
    }

    public override void UpdateBulletPosition()
    {
        base.UpdateBulletPosition();

        transform.localPosition += transform.up * speed * Time.deltaTime;
    }
}
