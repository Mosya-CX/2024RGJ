using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct BiodInfo
{
    // ����ֵ
    float size;
    // ����ֵ
    float life;
    // �ٶ�ֵ
    float speed;
    // ������ֵ
    float attack;
    // ������ֵ
    float defense;
    // �����ٶ�
    float mateSpeed;
    // ����Ƶ��
    float mateFrequency;
    // �ɳ�ֵ(���嶯��ɳ��׶�)
    float growth;
}

public class BaseBiod
{
    public BiodInfo baseInfo;

    // ���򲿷�
    // ���ɻ���

    // �ڲ�����

    // ʳ�Ի���

    // ����������ͻ���(Ӱ�����)

    // �����������ͻ���(Ӱ��ϰ��)


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
    public virtual void Death()
    {

    }

    // �ı����
    public virtual void ChangeGene(GeneType geneType, BaseGene gene)
    {

    }
}
