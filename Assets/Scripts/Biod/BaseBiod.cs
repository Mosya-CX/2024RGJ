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

public enum BiodState
{
    Move,
    Eat,
    Fight,
    Mathing,
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
    // 食性
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

    #region 移动相关
    public Vector3 curVelocity;//当前帧速度
    public Vector3 newVelocity;//新速度
    public Vector3 newPosition;//下一帧位置
    public List<BaseBiod> neighbors;//与当前个体相邻的其它个体
    public List<BaseBiod> collisionRisks;//与当前个体有碰撞风险的其它个体
    public BaseBiod closestOne;//与当前个体距离最近的其它个体

    public void ForagingUpdate(Vector3 targetPos)
    {

    }

    //更新相邻个体
    public void UpdateNeighbors(BaseBiod source, List<BaseBiod> biods)
    {
        float closestDist = float.MaxValue;
        Vector3 delta;// 与其他boid的三维距离
        float dist;// 三维距离转化的实数距离
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

    // 战斗(草食性动物不会主动战斗)
    public virtual void Fight(BaseBiod target)
    {

    }
    // 移动
    public virtual void Move()
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
                            Debug.Log("基因编号错误");
                        }
                        break;
                    case BiodType.Bird:
                        if (geneId >= 200 && geneId <= 202)
                        {
                            body.body = (BodyType)geneId;
                        }
                        else
                        {
                            Debug.Log("基因编号错误");
                        }
                        break;
                    case BiodType.Insect:
                        if (geneId >= 300 && geneId <= 302)
                        {
                            body.body = (BodyType)geneId;
                        }
                        else
                        {
                            Debug.Log("基因编号错误");
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
                    Debug.Log("基因编号错误");
                }
                break;
            case GeneType.Habit:

                break;
            case GeneType.Apparent:

                break;
        }
        RecountInfo();
    }
    // 根据基因重新计算数值信息
    public void RecountInfo()
    {
        info = new BiodInfo(baseInfo.size, baseInfo.life, baseInfo.speed, baseInfo.attack);
        body.AddEffect(info);

    }
}
