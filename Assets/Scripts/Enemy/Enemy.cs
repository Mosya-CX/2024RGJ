using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BaseEnemy enemyData;

    public BuffHandler buffHandler;

    public PlayerMovement player;// Ŀ��λ��
    public float nextNodeDistance = 3f;// �����ж��Ƿ񵽴��¸��ڵ���ٽ�ֵ

    Path path;// �洢Ҫ��ѭ��·��
    int currentNode = 0;// ��¼��ǰ�ƶ������ĸ��ڵ�
    bool isReached = false;// ��¼�Ƿ񵽴�����ִ�е�·�����յ�
    Seeker seeker;// ���ڼ���·��
    Rigidbody2D rb;// ʵ���ƶ��߼��õ����(���ò�����Rigidbody)

    float dist;// ��Ŀ��֮��ľ���

    //��ǰֵ
    public float currentSpeed;
    public float currentHealth;
    public int currentDamege;
    public bool isAttacking;


    private void Awake()
    {
        seeker = gameObject.GetComponent<Seeker>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(OnPathCounting), 0, 0.5f);
        buffHandler = gameObject.GetComponent<BuffHandler>();

        currentSpeed = enemyData.speed;
        currentHealth = enemyData.maxHealth;
        currentDamege = enemyData.damage;
    }

    private void Start()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);
    }

    private void Update()
    { 

        if (path == null)
        {
            Debug.LogWarning("·��Ϊ��");
            return;
        }

        // ����Ƿ񵽴�
        if (dist <= enemyData.attackDist)
        {
            isReached = true;
        }
        else
        {
            isReached = false;
        }
        if (!isReached)
        {
            Move();
        }
        else
        {
            if (!isAttacking)
            {
                isAttacking = true;
                // ִ�й���
                enemyData.attackAction.Attack(this);
            }
        }
    }

    private void LateUpdate()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);
    }

    void OnPathCounting()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, player.transform.position, OnCountCompelete);
        }
    }

    void OnCountCompelete(Path p)
    {
        // ���·���Ƿ��д���
        if (!p.error)
        {
            // ���û���򽫼���õ�·����ֵ���洢·���ĵط�
            path = p;
            currentNode = 0;// ���õ�ǰ�ڵ�
        }
    }

    private void Move()
    {
        // �����ƶ�����(����=Ŀ��ڵ�λ�� - ����λ��)
        Vector2 Dir = ((Vector2)path.vectorPath[currentNode] - rb.position).normalized;
        Vector2 Force = Dir * enemyData.speed * Time.deltaTime;// �����ƶ��ļ��ٶ�

        // �ж�AI����
        if (Dir.x > 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Dir.x < -0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        rb.AddForce(Force);
        // �ǵ�Ҫ��AI����һ������ 

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentNode]);// ��������¸��ڵ�ľ���
        if (distance < nextNodeDistance)
        {
            currentNode++;
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

}
