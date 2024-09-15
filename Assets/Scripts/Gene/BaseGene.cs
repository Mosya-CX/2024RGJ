using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GeneType
{
    Body,// 躯干
    Mouth,// 口部
    Habit,// 习性
    Apparent,// 表型
}

public enum HabitType
{
    Social,// 群居
    Solitude,// 独居
}

public enum ApparentType
{
    Shell,// 有壳的
    Hairy,// 多毛的
    Bald,// 无毛的
}

public enum BodyType
{
    Horse,// 马型
    Wolf,// 狼型
    Elephant,// 象型
    Spider,// 蜘蛛型
    Mantis,// 螳螂型
    Frog,// 青蛙型(跳跃足)
    Bat,// 蝙蝠型
    Dragon,// 龙型
    Eagle,// 鹰型
}

public enum MouthType
{
    BuckTooth,// 獠牙(肉食)
    FlatTooth,// 平齿(杂食)
    FrontTooth,// 门齿(草食)
}

public abstract class BaseGene
{
    public abstract GeneType geneType { get; }

    // 基因对数值的影响
    public abstract void AddEffect(BiodInfo biodInfo);

}
