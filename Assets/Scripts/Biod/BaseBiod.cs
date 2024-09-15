using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FeedingType
{
    Carnivore, //肉食
    Herbivore, //草食
    Omnivore //杂食
}

public enum BiodType
{
    Beast,
    Bird,
    Insect,
}

public struct BiodInfo
{
    // 体型值
    public float size;
    // 寿命值
    public float life;
    // 速度值
    public float speed;
    // 攻击力值
    public float attack;
    // 防御力值
    public float defense;
    // 食性
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
    // 成长值(定义动物成长阶段)
    public float growth;

    // 当前属性
    public BiodInfo info;

    // 基础属性
    public virtual BiodInfo baseInfo { get; }

    public virtual BiodType biodType { get; }
    public string uid;
    // 基因部分
    // 躯干基因
    public BodyGene body;
    // 口部基因
    public MouthGene mouth;
    // 辅助类表现型基因(影响外观)
    public ApparentGene apparent;
    // 辅助类内在型基因(影响习性)
    public HabitGene habit;
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
    public void Death()
    {
        GameManager.Instance.biods[uid].RemoveBiod(this);
        Destroy(gameObject,0.2f);
    }

    // 改变基因
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
    // 根据基因重新计算数值信息
    public void RecountInfo()
    {

    }
}
