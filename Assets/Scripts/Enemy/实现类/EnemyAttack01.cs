using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.Progress;
[CreateAssetMenu(menuName = "�������˹�����ʽ/����01", fileName = "Attack01")]
public class EnemyAttack01 : BaseAttack
{
    public float checkRadius;
    public float attackSpace = 0.5f;
    public override void Attack(Enemy enemyInfo)
    {
        Debug.Log("���˹���");
        ThreadPool.QueueUserWorkItem((o) =>
        {
            enemyInfo.player.TakeDamage(enemyInfo.currentDamege);
            Thread.Sleep((int)(attackSpace * 1000));
            enemyInfo.isAttacking = false;
        });
        
    }

}
