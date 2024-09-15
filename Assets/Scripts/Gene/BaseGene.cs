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
    Social = 510,// 群居
    Solitude = 511,// 独居
}

public enum ApparentType
{
    Shell = 500,// 有壳的
    Hairy = 501,// 多毛的
    Bald = 502,// 无毛的
}

public enum BodyType
{
    Horse = 100,// 马型
    Wolf = 101,// 狼型
    Elephant = 102,// 象型
    Spider = 200,// 蜘蛛型
    Mantis = 201,// 螳螂型
    Frog = 202,// 青蛙型(跳跃足)
    Bat = 300,// 蝙蝠型
    Dragon = 301,// 龙型
    Eagle = 302,// 鹰型
}

public enum MouthType
{
    BuckTooth = 0,// 獠牙(肉食)
    FlatTooth = 1,// 平齿(杂食)
    FrontTooth = 2,// 门齿(草食)
}

public abstract class BaseGene
{
    public abstract GeneType geneType { get; }

    // 基因对数值的影响
    public abstract void AddEffect(BiodInfo biodInfo);

}
