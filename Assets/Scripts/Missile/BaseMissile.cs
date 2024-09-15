using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "�����µ�Ͷ����", fileName = "newMissle")]
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
