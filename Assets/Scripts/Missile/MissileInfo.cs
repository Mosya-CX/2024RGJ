using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileInfo
{
    public BaseMissile missileData;
    public float durationTimer;
    public float cdTimer;
    public MissileInfo(BaseMissile missileData)
    {
        this.missileData = missileData;

    }
}
