using Pathfinding;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    Vector3 originScale;

    public BaseEnemy enemyData;

    public BuffHandler buffHandler;

    public PlayerMovement player;// Ŀ��λ��
    public float nextNodeDistance = 1f;// �����ж��Ƿ񵽴��¸��ڵ���ٽ�ֵ

    Path path;// �洢Ҫ��ѭ��·��
    int currentNode = 0;// ��¼��ǰ�ƶ������ĸ��ڵ�
    public bool isReached = false;// ��¼�Ƿ񵽴�����ִ�е�·�����յ�
    Seeker seeker;// ���ڼ���·��
    //Rigidbody2D rb;// ʵ���ƶ��߼��õ����(���ò�����Rigidbody)

    public float dist;// ��Ŀ��֮��ľ���

    //��ǰֵ
    public float currentSpeed;
    public float currentHealth;
    public int currentDamege;
    public bool isAttacking;
    public bool isApproachPlayer;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        seeker = gameObject.GetComponent<Seeker>();
        //rb = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(OnPathCounting), 0, 0.5f);
        buffHandler = gameObject.GetComponent<BuffHandler>();

        player = GameManager.Instance.playerData;

        currentSpeed = enemyData.speed;
        currentHealth = enemyData.maxHealth;
        currentDamege = enemyData.damage;

        originScale = transform.localScale;
    }

    private void Start()
    {
        dist = Vector2.Distance(transform.position, player.transform.position);
        EnemyManager.Instance.enemy1Count++;
    }

    private void Update()
    {
        SetAnimation();

        if (path == null)
        {
            Debug.LogWarning("·��Ϊ��");
            return;
        }

        // ����Ƿ񵽴�
        if (dist <= enemyData.attackDist)
        {
            isApproachPlayer = true;
        }
        else
        {
            isApproachPlayer = false;
        }
        if (currentNode >= path.vectorPath.Count)
        {
            isReached = true;
            return;
        }
        else
        {
            isReached = false;
        }

        if (!isReached && !isAttacking)
        {
            Move();
        }
        if (isApproachPlayer)
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
            seeker.StartPath(transform.position, player.transform.position, OnCountCompelete);
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
        Vector2 Dir = ((Vector2)path.vectorPath[currentNode] - (Vector2)transform.position).normalized;

        // �ж�AI����
        if (Dir.x > 0.01f)
        {
            transform.localScale = new Vector3(-originScale.x, originScale.y, originScale.z);
        }
        else if (Dir.x < -0.01f)
        {
            transform.localScale = new Vector3(originScale.x, originScale.y, originScale.z);
        }

        transform.position += (Vector3)Dir * enemyData.speed * Time.deltaTime; 

        float distance = Vector2.Distance(transform.position, path.vectorPath[currentNode]);// ��������¸��ڵ�ľ���
        if (distance < nextNodeDistance)
        {
            currentNode++;
        }
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        GetComponent<HurtShader>().PlayFlashFX();
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        EnemyManager.Instance.enemy1Count--;
        Destroy(gameObject);
        AudioManager.Instance.PlayEffect("��������");
    }

    public void SetAnimation()
    {
        anim.SetFloat("Velocity", currentSpeed);
    }
}
