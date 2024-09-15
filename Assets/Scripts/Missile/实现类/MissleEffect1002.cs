using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleEffect1002 : MissileEffect
{
    public override void BaseApply(MissileInfo info, Vector3 dir)
    {
        GameObject obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir)));
        // 获得子弹脚本
        Bullet1002 bullet = obj.GetComponent<Bullet1002>();
        bullet.speed = info.speed;
        bullet.damage = info.damage;
        bullet.duration = info.durationTime;
        bullet.bombRadius *= 1;
    }

    public override void GoodApply(MissileInfo info, Vector3 dir)
    {
        GameObject obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir)));
        // 获得子弹脚本
        Bullet1002 bullet = obj.GetComponent<Bullet1002>();
        bullet.speed = info.speed;
        bullet.damage = info.damage;
        bullet.duration = info.durationTime;
        bullet.bombRadius *= 1.2f;
    }

    public override void GreatApply(MissileInfo info, Vector3 dir)
    {
        GameObject obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir)));
        // 获得子弹脚本
        Bullet1002 bullet = obj.GetComponent<Bullet1002>();
        bullet.speed = info.speed;
        bullet.damage = info.damage * 1.2f;
        bullet.duration = info.durationTime;
        bullet.bombRadius *= 1.2f;
    }

    public override void NonApply(MissileInfo info, Vector3 dir)
    {
        throw new System.NotImplementedException();
    }

    public override void PrefectApply(MissileInfo info, Vector3 dir)
    {
        throw new System.NotImplementedException();
    }
}
