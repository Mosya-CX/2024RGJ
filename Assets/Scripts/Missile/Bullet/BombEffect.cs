using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    bool hasSetDamage = false;
    bool hasBomb = false;
    float damage;
    public void SetDamage(float damage)
    {
        this.damage = damage;
        hasSetDamage = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && hasSetDamage && !hasBomb && hasSetDamage)
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            hasBomb = true;
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy") && hasSetDamage && !hasBomb && hasSetDamage)
    //    {
    //        collision.GetComponent<Enemy>().TakeDamage(damage);
    //        hasBomb = true;
    //    }
    //}
}
