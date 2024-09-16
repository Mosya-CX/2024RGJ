using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "创建敌人攻击方式/攻击02", fileName = "Attack02")]
public class EnemyAttack02 : BaseAttack
{
    public float precastDelay = 0.5f;// 攻击前摇
    public float postcastDelay = 0.5f;// 攻击后摇
    public float attackSpace = 0.8f;// 攻击间隔
    public GameObject missilePrefab;// 子弹预制体
    public override void Attack(Enemy enemyInfo)
    {
        // 播放攻击动画

        ThreadPool.QueueUserWorkItem((callback) =>
        {
            Thread.Sleep((int)(precastDelay * 1000));
            
            // 生成子弹
            GameObject missile = Instantiate(missilePrefab, enemyInfo.transform.position, Quaternion.identity);
            // 获得子弹的脚本并设置方向


            Thread.Sleep((int)(postcastDelay * 1000));
            Thread.Sleep((int)(attackSpace * 1000));
            enemyInfo.isAttacking = false;
        });
    }
}
