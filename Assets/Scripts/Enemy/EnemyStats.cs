using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public BaseEnemy enemyData;

    //µ±Ç°Öµ
    float currentSpeed;
    float currentHealth;
    float currentDamege;

    void Awake()
    {
        currentSpeed = enemyData.speed;
        currentHealth = enemyData.maxHealth;
        currentDamege = enemyData.damage;

    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
