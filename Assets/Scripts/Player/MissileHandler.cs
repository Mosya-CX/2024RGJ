using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHandler : MonoBehaviour
{
    public List<MissileInfo> totalMissileList = new List<MissileInfo>();

    List<MissileInfo> availableList = new List<MissileInfo>();
    List<MissileInfo> activeList = new List<MissileInfo>();
    List<MissileInfo> disableList = new List<MissileInfo>();

    List<MissileInfo> disableCache = new List<MissileInfo>();
    List<MissileInfo> availableCache = new List<MissileInfo>();

    public float checkRadius = 5f;

    public void AddMissile(BaseMissile missile)
    {
        MissileInfo newInfo = new MissileInfo(missile);
        availableList.Add(newInfo);
        totalMissileList.Add(newInfo);
    }

    private void Update()
    {
        if (GameManager.Instance.currentState == GameStates.Paused)
        {
            return;
        }

        if (availableList.Count > 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // 找出距离最近的敌人
                Enemy closestEnemy = FindClosetEnemy();
                Vector3 dir = Vector3.zero;
                if (closestEnemy != null)
                {
                    dir = (closestEnemy.transform.position - transform.position).normalized;
                }
                else
                {
                    dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                }
                foreach (MissileInfo m in availableList)
                {
                    switch (m.grade)
                    {
                        case MissileGrade.Base:
                            m.missileData.effect.BaseApply(m, dir);
                            break;
                        case MissileGrade.Non:
                            m.missileData.effect.NonApply(m, dir);
                            break;
                        case MissileGrade.Good:
                            m.missileData.effect.GoodApply(m, dir);
                            break;
                            //case MissileGrade.Great:
                            //    m.missileData.effect.GreatApply(m, dir);
                            //    break;
                            //case MissileGrade.Perfect:
                            //    m.missileData.effect.PrefectApply(m, dir);
                            //    break;
                    }
                    if (m.missileData.isDuration)
                    {
                        m.durationTimer = m.durationTime;
                        activeList.Add(m);
                    }
                    else
                    {
                        m.cdTimer = m.attackSpace;
                        disableList.Add(m);
                    }
                }
                availableList.Clear();
            }
            
        }
        if (activeList.Count > 0)
        {
            foreach (MissileInfo m in activeList)
            {
                if (m.durationTimer > 0)
                {
                    m.durationTimer -= Time.deltaTime;
                }
                else
                {
                    disableCache.Add(m);
                }
            }
        }
        if (disableCache.Count > 0)
        {
            foreach(MissileInfo m in disableCache)
            {
                activeList.Remove(m);
                m.cdTimer = m.attackSpace;
                disableList.Add(m);
                m.durationTimer = 0;
            }
            disableCache.Clear();
        }
        if (disableList.Count > 0)
        {
            foreach (MissileInfo m in disableList)
            {
                if (m.cdTimer > 0)
                {
                    m.cdTimer -= Time.deltaTime;
                }
                else
                {
                    availableCache.Add(m);
                }
            }
        }
        if (availableCache.Count > 0)
        {
            foreach (MissileInfo m in availableCache)
            {
                availableList.Add(m);
                disableList.Remove(m);
                m.cdTimer = 0;
            }
            availableCache.Clear();
        }

    }

    public Enemy FindClosetEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, checkRadius);
        Enemy nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        // 遍历所有碰撞体
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                // 计算当前碰撞体与游戏对象之间的距离
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                // 如果当前碰撞体的距离小于之前找到的最小距离
                if (distance < nearestDistance)
                {
                    // 更新最近的碰撞体和距离
                    nearestEnemy = collider.GetComponent<Enemy>();
                    nearestDistance = distance;
                }
            }
        }

        return nearestEnemy;
    }

}
