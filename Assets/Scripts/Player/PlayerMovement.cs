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

    private void Awake()
    {
        missileHandler = GetComponent<MissileHandler>();
        rb = GetComponent<Rigidbody2D>();
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
    }

    public void TakeDamage(Vector3 enemyPos, int damage)
    {
        Vector3 hitDirection = transform.position - enemyPos;
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
