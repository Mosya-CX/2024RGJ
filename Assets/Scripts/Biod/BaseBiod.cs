using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FeedingType
{
    Carnivore, //��ʳ
    Herbivore, //��ʳ
    Omnivore //��ʳ
}

public enum BiodType
{
    Beast,
    Bird,
    Insect,
}

public struct BiodInfo
{
    // ����ֵ
    public float size;
    // ����ֵ
    public float life;
    // �ٶ�ֵ
    public float speed;
    // ������ֵ
    public float attack;
    // ������ֵ
    public float defense;
    // ʳ��
    public FeedingType feedingType;

    public BiodInfo(float size, float life, float speed, float attack, float defense)
    {
        this.size = size;
        this.life = life;
        this.speed = speed;
        this.attack = attack;
        this.defense = defense;
        this.feedingType = FeedingType.Herbivore;
    }
}

public class BaseBiod : MonoBehaviour
{
    // �ɳ�ֵ(���嶯��ɳ��׶�)
    public float growth;

    // ��ǰ����
    public BiodInfo info;

    // ��������
    public virtual BiodInfo baseInfo { get; }

    public virtual BiodType biodType { get; }
    public string uid;
    // ���򲿷�
    // ���ɻ���
    public BodyGene body;
    // �ڲ�����
    public MouthGene mouth;
    // ����������ͻ���(Ӱ�����)
    public ApparentGene apparent;
    // �����������ͻ���(Ӱ��ϰ��)
    public HabitGene habit;
    // ս��(��ʳ�Զ��ﲻ������ս��)
    public virtual void Fight(BaseBiod target)
    {

    }
    // ��ͨ�ƶ�
    public virtual void Move()
    {

    }
    // ����
    public virtual void Run()
    {

    }
    // ��ʳ
    public virtual void Eat()
    {

    }

    // ��ʳ
    public virtual void Foraging()
    {

    }

    // ����
    public virtual void Mathing()
    {

    }

    // ����
    public void Death()
    {
        GameManager.Instance.biods[uid].RemoveBiod(this);
        Destroy(gameObject,0.2f);
    }

    // �ı����
    public void ChangeGene(GeneType geneType, int geneId, BaseGene gene)
    {
        switch (geneType)
        {
            case GeneType.Body:
                switch ((BodyType)geneId)
                {

                }
                break;
            case GeneType.Mouth:

                break;
            case GeneType.Habit:

                break;
            case GeneType.Apparent:

                break;
        }
    }
    // ���ݻ������¼�����ֵ��Ϣ
    public void RecountInfo()
    {

    }
}
