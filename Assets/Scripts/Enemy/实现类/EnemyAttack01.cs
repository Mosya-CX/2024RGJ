using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "�������˹�����ʽ/����01", fileName = "Attack01")]
public class EnemyAttack01 : BaseAttack
{
    public float checkRadius;
    public override void Attack(Enemy enemyInfo)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemyInfo.transform.position, checkRadius);
        foreach (var item in colliders)
        {
            if (item.CompareTag("Player"))
            {
                // ���Ź�������

                // ���Ź�����Ч

                // ִ�й����߼�
                item.GetComponent<PlayerMovement>().TakeDamage(enemyInfo.transform.position, enemyInfo.currentDamege);
            }
        }
    }

}
