using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GeneType
{
    Body,// ����
    Mouth,// �ڲ�
    Habit,// ϰ��
    Apparent,// ����
}

public enum HabitType
{
    Social = 510,// Ⱥ��
    Solitude = 511,// ����
}

public enum ApparentType
{
    Shell = 500,// �пǵ�
    Hairy = 501,// ��ë��
    Bald = 502,// ��ë��
}

public enum BodyType
{
    Horse = 100,// ����
    Wolf = 101,// ����
    Elephant = 102,// ����
    Spider = 200,// ֩����
    Mantis = 201,// �����
    Frog = 202,// ������(��Ծ��)
    Bat = 300,// ������
    Dragon = 301,// ����
    Eagle = 302,// ӥ��
}

public enum MouthType
{
    BuckTooth = 0,// ���(��ʳ)
    FlatTooth = 1,// ƽ��(��ʳ)
    FrontTooth = 2,// �ų�(��ʳ)
}

public abstract class BaseGene
{
    public abstract GeneType geneType { get; }

    // �������ֵ��Ӱ��
    public abstract void AddEffect(BiodInfo biodInfo);

}
