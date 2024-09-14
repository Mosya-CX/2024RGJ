using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GeneType
{
    Body,// 躯干
    Mouth,// 口部
    Feeding,// 食性
    Habit,// 习性
    Apparent,// 表型
}

public enum FeedingType
{
    Carnivore, //肉食
    Herbivore, //草食
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

    // 基因对数值的影响
    public abstract void AddEffect(BiodInfo biodInfo);
    public abstract void RemoveEffect(BiodInfo biodInfo);

}
