using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("参数")]
    public float moveSpeed;  //移速
    public int hp; //生命值
    public int shield;// 护盾
    public float knockBackForce; //击退力

    Rigidbody2D rb;
    Vector2 moveDir;  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        InputManagement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2 (moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    public void TakeDamage(Vector3 hitDirection)
    {
        if (shield > 0)
        {
            shield--;
        }
        else
        {
            hp--;
        }
        // 播放动画

        // 收到击退
        rb.AddForce(hitDirection * knockBackForce, ForceMode2D.Impulse);

        if (hp <= 0)
        {
            // 游戏结束

        }

    }

}
