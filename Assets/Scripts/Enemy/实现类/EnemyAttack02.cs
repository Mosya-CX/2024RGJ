using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "�������˹�����ʽ/����02", fileName = "Attack02")]
public class EnemyAttack02 : BaseAttack
{
    public float precastDelay = 0.5f;// ����ǰҡ
    public float postcastDelay = 0.5f;// ������ҡ
    //public float attackSpace = 0.8f;// �������
    public GameObject missilePrefab;// �ӵ�Ԥ����
    public override void Attack(Enemy enemyInfo)
    {
        // ���Ź�������


        AttackAsync(enemyInfo);

        //ThreadPool.QueueUserWorkItem((callback) =>
        //{
        //    Thread.Sleep((int)(precastDelay * 1000));
            
        //    Thread.Sleep((int)(postcastDelay * 1000));
        //    Debug.Log("���˹���02����");
        //    enemyInfo.isAttacking = false;
        //});
    }

    public async void AttackAsync(Enemy enemyInfo)
    {
        await Task.Delay((int)(precastDelay * 1000));
        Debug.Log("���˹���02");
        // �����ӵ�
        Vector3 dir = enemyInfo.player.transform.position - enemyInfo.transform.position;
        GameObject missile = GameObject.Instantiate(missilePrefab, enemyInfo.transform.position, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir)));
        EnemyBullet01 bullet = missile.GetComponent<EnemyBullet01>();
        bullet.damage = enemyInfo.currentDamege;
        Debug.Log("�ӵ��˺�" + bullet.damage);
        await Task.Delay((int)(postcastDelay* 1000));
        Debug.Log("���˹���02����");
        enemyInfo.isAttacking = false;
    }
}
