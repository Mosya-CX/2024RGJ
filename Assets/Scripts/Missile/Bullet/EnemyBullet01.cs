using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet01 : MonoBehaviour
{
    public float speed = 3f;
    public float duration = 15;
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D:" + collision.tag);
        if (collision.tag == "Player")
        {
            Debug.Log("ºÏ≤‚µΩµ–»À");
            EffectOnEnter(collision.GetComponent<PlayerMovement>());
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

    public void EffectOnEnter(PlayerMovement info)
    {
        info.TakeDamage(damage);
        Destroy(gameObject);
    }
    public void UpdateBulletPosition()
    {
        transform.localPosition += transform.up * speed * Time.deltaTime;
    }
}
