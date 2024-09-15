using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public float speed;
    public float duration;
    public float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EffectOnEnter(collision.GetComponent<Enemy>());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EffectOnStay(collision.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EffectOnExit(collision.GetComponent<Enemy>());
        }
    }

    private void Update()
    {
        UpdateBulletPosition();
        if (duration > 0)
        {
            duration -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public virtual void EffectOnEnter(Enemy info)
    {

    }
    public virtual void EffectOnStay(Enemy info)
    {

    }
    public virtual void EffectOnExit(Enemy info)
    {

    }
    public virtual void UpdateBulletPosition()
    {

    }
}
