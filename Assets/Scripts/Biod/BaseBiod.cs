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

public enum BiodState
{
    Move,
    Eat,
    Fight,
    Mathing,
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
    // ʳ��
    public FeedingType feedingType;

    public BiodInfo(float size, float life, float speed, float attack)
    {
        this.size = size;
        this.life = life;
        this.speed = speed;
        this.attack = attack;
        this.feedingType = FeedingType.Herbivore;
    }
}

public class BaseBiod : MonoBehaviour
{
    public BiodManager manager;

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

    #region �ƶ����
    public Vector3 curVelocity;//��ǰ֡�ٶ�
    public Vector3 newVelocity;//���ٶ�
    public Vector3 newPosition;//��һ֡λ��
    public List<BaseBiod> neighbors;//�뵱ǰ�������ڵ���������
    public List<BaseBiod> collisionRisks;//�뵱ǰ��������ײ���յ���������
    public BaseBiod closestOne;//�뵱ǰ��������������������

    public void ForagingUpdate(Vector3 targetPos)
    {

    }

    //�������ڸ���
    public void UpdateNeighbors(BaseBiod source, List<BaseBiod> biods)
    {
        float closestDist = float.MaxValue;
        Vector3 delta;// ������boid����ά����
        float dist;// ��ά����ת����ʵ������
        neighbors.Clear();
        collisionRisks.Clear();
        foreach (BaseBiod b in biods)
        {
            if (b == source)
            {
                continue;
            }
            delta = b.transform.position - source.transform.position;
            dist = delta.magnitude;
            if (dist < closestDist)
            {
                closestDist = dist;
                closestOne = b;
            }
            if (dist < manager.nearDist)
            {
                neighbors.Add(b);
            }
            if (dist < manager.collisionDist)
            {
                collisionRisks.Add(b);
            }
        }
        if (neighbors.Count == 0)
        {
            neighbors.Add(closestOne);
        }
    }
    public Vector3 GetAverageVelocity(List<BaseBiod> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (BaseBiod b in someBoids)
        {
            sum += b.curVelocity;
        }
        return sum / someBoids.Count;
    }
    public Vector3 GetAveragePosition(List<BaseBiod> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (BaseBiod b in someBoids)
        {
            sum += b.transform.position;
        }
        return sum / someBoids.Count;
    }
    #endregion

    // ս��(��ʳ�Զ��ﲻ������ս��)
    public virtual void Fight(BaseBiod target)
    {

    }
    // �ƶ�
    public virtual void Move()
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
    public void ChangeGene(GeneType geneType, int geneId)
    {
        switch (geneType)
        {
            case GeneType.Body:
                switch (biodType)
                {
                    case BiodType.Beast:
                        if (geneId >= 100 && geneId <= 102)
                        {
                            body.body = (BodyType)geneId;
                        }
                        else
                        {
                            Debug.Log("�����Ŵ���");
                        }
                        break;
                    case BiodType.Bird:
                        if (geneId >= 200 && geneId <= 202)
                        {
                            body.body = (BodyType)geneId;
                        }
                        else
                        {
                            Debug.Log("�����Ŵ���");
                        }
                        break;
                    case BiodType.Insect:
                        if (geneId >= 300 && geneId <= 302)
                        {
                            body.body = (BodyType)geneId;
                        }
                        else
                        {
                            Debug.Log("�����Ŵ���");
                        }
                        break;
                }
                break;
            case GeneType.Mouth:
                if (geneId >= 0 && geneId <= 2)
                {
                    //mouth.mouth = (MouthType)geneId;
                }
                else
                {
                    Debug.Log("�����Ŵ���");
                }
                break;
            case GeneType.Habit:

                break;
            case GeneType.Apparent:

                break;
        }
        RecountInfo();
    }
    // ���ݻ������¼�����ֵ��Ϣ
    public void RecountInfo()
    {
        info = new BiodInfo(baseInfo.size, baseInfo.life, baseInfo.speed, baseInfo.attack);
        body.AddEffect(info);

    }
}
