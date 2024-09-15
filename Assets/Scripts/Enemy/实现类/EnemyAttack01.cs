using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;
[CreateAssetMenu(menuName = "创建敌人攻击方式/攻击01", fileName = "Attack01")]
public class EnemyAttack01 : BaseAttack
{
    public float checkRadius;
    public override void Attack(Enemy enemyInfo)
    {
        enemyInfo.player.TakeDamage(enemyInfo.transform.position, enemyInfo.currentDamege);
    }

}
