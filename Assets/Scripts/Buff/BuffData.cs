using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buff系统/NewBuff", fileName = "NewBuff")]
public class BuffData : ScriptableObject
{
    [Header("基础信息")]
    public int Id;
    public string Name;
    public string Description;
    public Sprite Icon;
    public int Priority;
    public bool isStackable;
    public int MaxStack;
    public string[] Tags;
    [Header("时间信息")]
    public bool isForever;
    public float Duration;
    public float TickTime;
    [Header("更新方式")]
    public BuffUpdateTimeEnum UpdateTimeMode;
    public BuffRemoveUpdateEnum RemoveUpdateMode;
    [Header("基础回调点")]
    public BaseBuffModule OnCreate;
    public BaseBuffModule OnRemove;
    public BaseBuffModule OnTick;
    [Header("伤害回调点")]
    public BaseBuffModule OnHit;// 当 攻击 时
    public BaseBuffModule OnHurt;// 当 受伤/受击 时
    public BaseBuffModule OnKill;// 当 击杀 时
    public BaseBuffModule OnDeath;// 当 死亡/被击杀 时
}
