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
    Animator anim;
    SpriteRenderer spriteRenderer;
    float speed;//当前速度

    private void Awake()
    {
        missileHandler = GetComponent<MissileHandler>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        missileHandler.AddMissile(Resources.Load<BaseMissile>("Data/ScriptableObject/Missile/Missle1000"));
    }

    private void Update()
    {
        UpdateDir();
        SetAnimation();
    }

    public void UpdateDir()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.magnitude > 0)
        {
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

    }

    private void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
        speed = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y);
    }

    public void TakeDamage(int damage)
    {
        AudioManager.Instance.PlayEffect("受伤");
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
            hp -= damage;
        }
      
        // 播放动画

        if (hp <= 0)
        {
            // 游戏结束
            Application.Quit();
        }

    }

    public void SetAnimation()
    {
        anim.SetFloat("Velocity", speed);
    }

}
