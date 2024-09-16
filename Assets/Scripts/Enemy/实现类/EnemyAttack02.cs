using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "创建敌人攻击方式/攻击02", fileName = "Attack02")]
public class EnemyAttack02 : BaseAttack
{
    public float precastDelay = 0.5f;// 攻击前摇
    public float postcastDelay = 0.5f;// 攻击后摇
    //public float attackSpace = 0.8f;// 攻击间隔
    public GameObject missilePrefab;// 子弹预制体
    public override void Attack(Enemy enemyInfo)
    {
        // 播放攻击动画


        AttackAsync(enemyInfo);

        //ThreadPool.QueueUserWorkItem((callback) =>
        //{
        //    Thread.Sleep((int)(precastDelay * 1000));
            
        //    Thread.Sleep((int)(postcastDelay * 1000));
        //    Debug.Log("敌人攻击02结束");
        //    enemyInfo.isAttacking = false;
        //});
    }

    public async void AttackAsync(Enemy enemyInfo)
    {
        await Task.Delay((int)(precastDelay * 1000));
        Debug.Log("敌人攻击02");
        // 生成子弹
        Vector3 dir = enemyInfo.player.transform.position - enemyInfo.transform.position;
        GameObject missile = GameObject.Instantiate(missilePrefab, enemyInfo.transform.position, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir)));
        EnemyBullet01 bullet = missile.GetComponent<EnemyBullet01>();
        bullet.damage = enemyInfo.currentDamege;
        Debug.Log("子弹伤害" + bullet.damage);
        await Task.Delay((int)(postcastDelay* 1000));
        Debug.Log("敌人攻击02结束");
        enemyInfo.isAttacking = false;
    }
}
