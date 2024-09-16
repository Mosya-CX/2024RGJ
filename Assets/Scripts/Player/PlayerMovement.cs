using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("����")]
    public float moveSpeed;  //����
    public int hp; //����ֵ
    public int shield;// ����
    public float knockBackForce; //������
    public float knockDuration; //����ʱ��
    private Vector2 knockDir; //���˷���

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
        // ���Ŷ���

        if (hp <= 0)
        {
            // ��Ϸ����

        }

    }

}
