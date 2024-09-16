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
    public float knockDuration; //击退时间
    private Vector2 knockDir; //击退方向

    Rigidbody2D rb;
    Vector2 moveDir;  
    public MissileHandler missileHandler;
    private Animator animator;

    private void Awake()
    {
        missileHandler = GetComponent<MissileHandler>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateDir();
    }

    public void UpdateDir()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        if(rb.velocity==new Vector2(0,0))
        {
            animator.SetBool("Is run", false);
        }
        else
        {
            animator.SetBool("Is run", true);
        }
    }

    public void TakeDamage(int damage)
    {
        if (shield > 0)
        {
            if (shield >= damage)
            {
                shield -= damage;
            }
            else
            {
                shield = 0;
                hp -= damage - shield;
            }
        }
        else
        {
            hp-= damage;
        }
        // 播放动画

        if (hp <= 0)
        {
            // 游戏结束

        }

    }

}
