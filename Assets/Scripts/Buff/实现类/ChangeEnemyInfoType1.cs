using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Buff系统/Buff效果/ChangeEnemyInfoType1", fileName = "ChangeEnemyInfoType1")]
public class ChangeEnemyInfoType1 : BaseBuffModule
{
    public EnemyValueAmt valueToChange;
    public override void Apply(BuffInfo buffInfo, DamageInfo damageInfo = null)
    {
        Enemy enemy = buffInfo.target.GetComponent<Enemy>();
        enemy.currentSpeed *= valueToChange.speedAmt;
        enemy.currentHealth *= valueToChange.hpAmt;
        enemy.currentDamege *= valueToChange.damegeAmt;
    }
}
[Serializable]
public class EnemyValueAmt
{
    public float speedAmt;
    public float hpAmt;
    public int damegeAmt;
}
