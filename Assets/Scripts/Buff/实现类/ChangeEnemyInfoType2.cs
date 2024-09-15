using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Buff系统/Buff效果/ChangeEnemyInfoType2", fileName = "ChangeEnemyInfoType2")]
public class ChangeEnemyInfoType2 : BaseBuffModule
{
    public EnemyValueAdd valueToChange;
    public override void Apply(BuffInfo buffInfo, DamageInfo damageInfo = null)
    {
        Enemy enemy = buffInfo.target.GetComponent<Enemy>();
        enemy.currentSpeed += valueToChange.speedAdd;
        enemy.currentHealth += valueToChange.hpAdd;
        enemy.currentDamege += valueToChange.damegeAdd;
    }
}
[Serializable]
public class EnemyValueAdd
{
    public float speedAdd;
    public float hpAdd;
    public int damegeAdd;
}
