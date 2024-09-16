using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1001 : BaseBullet
{
    public float damageAmt = 0.5f;
    public override void EffectOnEnter(Enemy info)
    {
        base.EffectOnEnter(info);
        info.TakeDamage(damage);
        damage *= damageAmt;
    }

    public override void UpdateBulletPosition()
    {
        base.UpdateBulletPosition();
        Debug.Log("Bullet 1001 Update");
        transform.localPosition += transform.up * speed * Time.deltaTime;
    }
}
