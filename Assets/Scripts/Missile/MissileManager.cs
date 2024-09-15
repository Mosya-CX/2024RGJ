using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : SingletonWithMono<MissileManager>
{
    public List<BaseMissile> missileList = new List<BaseMissile>();

    public BaseMissile RandomMissile()
    {
        return missileList[Random.Range(0, missileList.Count)];
    }
    
}
