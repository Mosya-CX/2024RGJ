using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Buffϵͳ/BuffЧ��/TakeEnemyDamage", fileName = "TakeEnemyDamage")]
public class TakeEnemyDamage : BaseBuffModule
{
    public float damage;
    public override void Apply(BuffInfo buffInfo, DamageInfo damageInfo = null)
    {
        (buffInfo.target.GetComponent<Enemy>()).TakeDamage(damage);
    }
}
