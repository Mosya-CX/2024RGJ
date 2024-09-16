using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1002 : BaseBullet
{
    public float bombRadius = 3f;
    public override void EffectOnEnter(Enemy info)
    {
        base.EffectOnEnter(info);

        speed = 0;
        // 播放爆炸特效

        // 执行爆炸效果
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        Destroy(gameObject, 0.15f);
    }

    public override void UpdateBulletPosition()
    {
        base.UpdateBulletPosition();

        transform.localPosition += transform.up * speed * Time.deltaTime;
    }
}
