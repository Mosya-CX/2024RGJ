using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "创建新的投掷物", fileName = "newMissle")]
public class BaseMissile : ScriptableObject
{
    public float attackSpace;// 攻击间隔
    public float damage;// 攻击伤害
    public bool isDuration;
    public float durationTime;// 投掷物持续时间
    public float speed;// 投掷物速度
    public float size;// 投掷物大小
    public uint number;// 投掷物数量
    public GameObject prefabe;
    public MissileEffect effect;
}
