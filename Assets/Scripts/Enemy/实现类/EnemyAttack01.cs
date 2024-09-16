using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;
[CreateAssetMenu(menuName = "创建敌人攻击方式/攻击01", fileName = "Attack01")]
public class EnemyAttack01 : BaseAttack
{
    public float checkRadius;
    public float attackSpace = 0.5f;
    public override void Attack(Enemy enemyInfo)
    {
        Debug.Log("敌人攻击");
        ThreadPool.QueueUserWorkItem((o) =>
        {
            enemyInfo.player.TakeDamage(enemyInfo.currentDamege);
            Thread.Sleep((int)(attackSpace * 1000));
            enemyInfo.isAttacking = false;
        });
        
    }

}
