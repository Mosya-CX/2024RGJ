using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GeneType
{
    Body,// ����
    Mouth,// �ڲ�
    Feeding,// ʳ��
    Habit,// ϰ��
    Apparent,// ����
}

public enum FeedingType
{
    Carnivore, //��ʳ
    Herbivore, //��ʳ
}

public enum HabitType
{

}

public enum ApparentType
{

}

public enum BodyType
{

}

public enum MouthType
{

}

public abstract class BaseGene
{
    public abstract GeneType geneType { get; }

    // �������ֵ��Ӱ��
    public abstract void AddEffect(BiodInfo biodInfo);
    public abstract void RemoveEffect(BiodInfo biodInfo);

}
