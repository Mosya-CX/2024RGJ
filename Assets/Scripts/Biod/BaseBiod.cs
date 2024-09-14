using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct BiodInfo
{
    // 体型值
    float size;
    // 寿命值
    float life;
    // 速度值
    float speed;
    // 攻击力值
    float attack;
    // 防御力值
    float defense;
    // 交配速度
    float mateSpeed;
    // 交配频率
    float mateFrequency;
    // 成长值(定义动物成长阶段)
    float growth;
}

public class BaseBiod
{
    public BiodInfo baseInfo;

    // 基因部分
    // 躯干基因

    // 口部基因

    // 食性基因

    // 辅助类表现型基因(影响外观)

    // 辅助类内在型基因(影响习性)


    // 战斗(草食性动物不会主动战斗)
    public virtual void Fight(BaseBiod target)
    {

    }
    // 普通移动
    public virtual void Move()
    {

    }
    // 奔跑
    public virtual void Run()
    {

    }
    // 进食
    public virtual void Eat()
    {

    }
    
    // 觅食
    public virtual void Foraging()
    {

    }

    // 交配
    public virtual void Mathing()
    {

    }

    // 死亡
    public virtual void Death()
    {

    }

    // 改变基因
    public virtual void ChangeGene(GeneType geneType, BaseGene gene)
    {

    }
}
