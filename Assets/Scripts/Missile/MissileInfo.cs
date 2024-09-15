using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissileGrade
{
    Base,
    Non,
    Good,
    Great,
    Perfect
}

public class MissileInfo
{
    public BaseMissile missileData;

    public float attackSpace;
    public float damage;
    public bool isDuration;
    public float durationTime;
    public float speed;
    public float size;
    public uint number;
    public MissileGrade grade;

    public float durationTimer;
    public float cdTimer;
    public MissileInfo(BaseMissile missileData)
    {
        this.missileData = missileData;
        attackSpace = missileData.attackSpace;
        damage = missileData.damage;
        isDuration = missileData.isDuration;
        durationTime = missileData.durationTime;
        speed = missileData.speed;
        size = missileData.size;
        number = missileData.number;
    }
}
