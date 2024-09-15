using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHandler : MonoBehaviour
{
    List<MissileInfo> availableList = new List<MissileInfo>();
    List<MissileInfo> activeList = new List<MissileInfo>();
    List<MissileInfo> disableList = new List<MissileInfo>();

    List<MissileInfo> disableCache = new List<MissileInfo>();
    List<MissileInfo> availableCache = new List<MissileInfo>();

    public float checkRadius = 5f;

    public void AddMissile(BaseMissile missile)
    {
        availableList.Add(new MissileInfo(missile));
    }

    private void Update()
    {
        if (availableList.Count > 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // �ҳ���������ĵ���
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

                    m.durationTimer = m.missileData.durationTime;
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
                m.cdTimer = m.missileData.attackSpace;
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

        // ����������ײ��
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                // ���㵱ǰ��ײ������Ϸ����֮��ľ���
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                // �����ǰ��ײ��ľ���С��֮ǰ�ҵ�����С����
                if (distance < nearestDistance)
                {
                    // �����������ײ��;���
                    nearestEnemy = collider.GetComponent<Enemy>();
                    nearestDistance = distance;
                }
            }
        }

        return nearestEnemy;
    }

}
