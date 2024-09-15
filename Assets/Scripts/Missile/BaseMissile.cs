using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "�����µ�Ͷ����", fileName = "newMissle")]
public class BaseMissile : ScriptableObject
{
    public float attackSpace;// �������
    public float damage;// �����˺�
    public bool isDuration;
    public float durationTime;// Ͷ�������ʱ��
    public float speed;// Ͷ�����ٶ�
    public float size;// Ͷ�����С
    public uint number;// Ͷ��������
    public GameObject prefabe;
    public MissileEffect effect;
}
