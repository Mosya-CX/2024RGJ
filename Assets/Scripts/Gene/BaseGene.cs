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
    Social,// Ⱥ��
    Solitude,// ����
}

public enum ApparentType
{
    Shell,// �пǵ�
    Hairy,// ��ë��
    Bald,// ��ë��
}

public enum BodyType
{
    Horse,// ����
    Wolf,// ����
    Elephant,// ����
    Spider,// ֩����
    Mantis,// �����
    Frog,// ������(��Ծ��)
    Bat,// ������
    Dragon,// ����
    Eagle,// ӥ��
}

public enum MouthType
{
    BuckTooth,// ���(��ʳ)
    FlatTooth,// ƽ��(��ʳ)
    FrontTooth,// �ų�(��ʳ)
}

public abstract class BaseGene
{
    public abstract GeneType geneType { get; }

    // �������ֵ��Ӱ��
    public abstract void AddEffect(BiodInfo biodInfo);

}
