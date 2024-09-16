using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1002 : BaseBullet
{
    public GameObject bombEffectObj;
    //public float bombRadius = 1.2f;
    public override void EffectOnEnter(Enemy info)
    {
        base.EffectOnEnter(info);

        speed = 0;
        // ���ű�ը��Ч
        GameObject bombEffect = Instantiate(bombEffectObj, transform.position, Quaternion.identity);
        bombEffect.GetComponent<BombEffect>().SetDamage(damage);
        Destroy(bombEffect, 0.1f);
        // ִ�б�ըЧ��
        //Collider[] colliders = Physics.OverlapSphere(transform.position, bombRadius);
        //foreach (Collider collider in colliders)
        //{
        //    if (collider.CompareTag("Enemy"))
        //    {
        //        collider.GetComponent<Enemy>().TakeDamage(damage);
        //    }
        //}

        Destroy(gameObject, 0.15f);
    }

    public override void UpdateBulletPosition()
    {
        base.UpdateBulletPosition();

        transform.localPosition += transform.up * speed * Time.deltaTime;
    }
}
