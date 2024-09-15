using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "´´½¨µÐÈË¹¥»÷·½Ê½/¹¥»÷01", fileName = "Attack01")]
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
                // ²¥·Å¹¥»÷¶¯»­

                // ²¥·Å¹¥»÷ÒôÐ§

                // Ö´ÐÐ¹¥»÷Âß¼­
                item.GetComponent<PlayerMovement>().TakeDamage(enemyInfo.transform.position, enemyInfo.currentDamege);
            }
        }
    }

}
