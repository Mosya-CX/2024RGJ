using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1000 : BaseBullet
{
    public override void EffectOnEnter(Enemy info)
    {
        base.EffectOnEnter(info);
        info.TakeDamage(damage);

        Destroy(gameObject);
    }

    public override void UpdateBulletPosition()
    {
        base.UpdateBulletPosition();

        Debug.Log(transform.forward);
        Debug.Log(speed);
        Debug.Log(Time.deltaTime);
        transform.localPosition += transform.up * speed * Time.deltaTime;
    }
}
