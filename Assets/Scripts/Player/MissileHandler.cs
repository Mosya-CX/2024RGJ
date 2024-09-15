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
    public void AddMissile(BaseMissile missile)
    {
        availableList.Add(new MissileInfo(missile));
    }

    private void Update()
    {
        if (availableList.Count > 0)
        {
            foreach (MissileInfo m in availableList)
            {
                m.missileData.effect.Apply(m);
                m.durationTimer = m.missileData.durationTime;
            }
            availableList.Clear();
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

}
