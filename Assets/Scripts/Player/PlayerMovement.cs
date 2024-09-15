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
        // ���Ŷ���

        // �յ�����
        rb.AddForce(hitDirection * knockBackForce, ForceMode2D.Impulse);

        if (hp <= 0)
        {
            // ��Ϸ����

        }

    }

}
