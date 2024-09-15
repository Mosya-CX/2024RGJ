using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "创建新的投掷物", fileName = "newMissle")]
public class BaseMissile : ScriptableObject
{
    public float attackSpace;
    public float damage;
    public bool isDuration;
    public float durationTime;
    public float speed;
    public float size;
    public Sprite image;
    public MissileEffect effect;
}
