using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(menuName = "�������˹�����ʽ/����02", fileName = "Attack02")]
public class EnemyAttack02 : BaseAttack
{
    public float precastDelay = 0.5f;// ����ǰҡ
    public float postcastDelay = 0.5f;// ������ҡ
    public float attackSpace = 0.8f;// �������
    public GameObject missilePrefab;// �ӵ�Ԥ����
    public override void Attack(Enemy enemyInfo)
    {
        // ���Ź�������

        ThreadPool.QueueUserWorkItem((callback) =>
        {
            Thread.Sleep((int)(precastDelay * 1000));
            
            // �����ӵ�
            GameObject missile = Instantiate(missilePrefab, enemyInfo.transform.position, Quaternion.identity);
            // ����ӵ��Ľű������÷���


            Thread.Sleep((int)(postcastDelay * 1000));
            Thread.Sleep((int)(attackSpace * 1000));
            enemyInfo.isAttacking = false;
        });
    }
}
